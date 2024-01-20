using CAO.Blackjack.Core.Data;
using CAO.Blackjack.Core.Enum;
using CAO.Blackjack.Core.Models;
using CAO.Blackjack.Core.Utils;
using CAO.Blackjack.Forms.Models;
using CAO.Blackjack.Forms.Properties;
using CAO.Blackjack.Forms.Utils;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// The application's game form, acting as the main game screen.
    /// </summary>
    public partial class FormGame : Form
    {
        #region Constants

        /// <summary>
        /// The maximum betting amount.
        /// </summary>
        private const int MaximumBetAmount = 10000;

        #endregion

        #region Private Members

        /// <summary>
        /// The dealer card UI panels
        /// </summary>
        private readonly Panel[] dealerCardPanels;

        /// <summary>
        /// The player card UI panels
        /// </summary>
        private readonly Panel[] playerCardPanels;

        /// <summary>
        /// The internal game state
        /// </summary>
        private GameState state = CommonUtils.CreateNewGameState();

        #endregion

        #region Ctor(s)
        /// <summary>
        /// Instantiates a new game form.
        /// </summary>
        public FormGame()
        {
            InitializeComponent();
            
            // Enabling this reduces flicker, but negatively impacts refresh speed unfortunately.
            //this.EnableDoubleBuffered(true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            
            dealerCardPanels = flowPanelDealerCards.Controls
                                                   .OfType<Panel>()
                                                   .ToArray();

            playerCardPanels = flowPanelPlayerCards.Controls
                                                   .OfType<Panel>()
                                                   .ToArray();



            LoadGameState();
            UpdateUI();
        }
        #endregion

        #region Game Methods
        /// <summary>
        /// Loads the game data from a file.
        /// </summary>
        private void LoadGameState()
        {
            GameState? loadedState = CommonUtils.LoadGameSaveFile();
            CommonUtils.TryCopyGameStateToCurrentState(ref state, loadedState);

            if (loadedState?.ActiveBackgroundId != null)
            {
                BackgroundImage = ImageUtils.GetBitmapResource(loadedState.ActiveBackgroundId);
            }
            else
            {
                BackgroundImage = ImageUtils.GetBitmapResource("bg_default");
            }

            state.PropertyChanged += State_PropertyChanged;
        }

        /// <summary>
        /// Initializes the game then starts the current match, starting the first turn.
        /// </summary>
        private void StartMatch()
        {
            state.InProgress = true;

            InitializeGame();

            AudioUtils.Play(AudioUtils.Sounds.SfxShuffle);
            ExecutionTimeUtils.WaitForSeconds(2.5f);
            state.Deck?.Shuffle();

            DealInitialCards();
        }

        /// <summary>
        /// Determine the match outcome based on current state.
        /// </summary>
        /// <returns>The match outcome.</returns>
        private MatchResult DetermineMatchOutcome()
        {
            if (state.DealerHand?.Sum > 21)
            {
                return MatchResult.DealerBust;
            }
            else if (state.DealerHand?.Sum == 21 && state.PlayerHand?.Sum < 21)
            {
                return MatchResult.DealerWin;
            }
            else if (state.DealerHand?.Sum == state.PlayerHand?.Sum)
            {
                return MatchResult.Tie;
            }
            else if (state.DealerHand?.Sum > state.PlayerHand?.Sum)
            {
                return MatchResult.DealerWin;
            }
            else if (state.DealerHand?.Sum > 21)
            {
                return MatchResult.DealerBust;
            }
            else if (state.PlayerHand?.Sum == 21 && state.DealerHand?.Sum == 21)
            {
                return MatchResult.Tie;
            }
            else
            {
                return MatchResult.PlayerWin;
            }
        }

        /// <summary>
        /// Ends the current match.
        /// </summary>
        /// <param name="result">The result of the match.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the result was unhandled due to an unknown value.</exception>
        private void EndMatch(MatchResult result)
        {
            int paidOut;

            switch (result)
            {
                case MatchResult.PlayerForfeit:
                    AudioUtils.Play(AudioUtils.Sounds.SfxExit);
                    break;
                case MatchResult.PlayerBust:
                    state.LossCount++;
                    AudioUtils.Play(AudioUtils.Sounds.SfxLose);
                    Card? wouldBeNextCard = state.Deck?.DealCard();
                    DialogUtils.ShowInfo(string.Format(Resources.InfoPlayerBust, wouldBeNextCard?.Name ?? "n/a", wouldBeNextCard?.Value));
                    break;
                case MatchResult.DealerBust:
                    state.WinCount++;
                    CashOut(true, out paidOut);
                    AudioUtils.Play(AudioUtils.Sounds.SfxWin);
                    DialogUtils.ShowInfo(string.Format(Resources.InfoDealerBust, paidOut.ToString("C0")));
                    break;
                case MatchResult.PlayerWin:
                    state.WinCount++;
                    CashOut(true, out paidOut);
                    AudioUtils.Play(AudioUtils.Sounds.SfxWin);
                    DialogUtils.ShowInfo(string.Format(Resources.InfoPlayerWin, paidOut.ToString("C0")));
                    break;
                case MatchResult.DealerWin:
                    state.LossCount++;
                    AudioUtils.Play(AudioUtils.Sounds.SfxLose);
                    DialogUtils.ShowInfo(Resources.InfoDealerWin);
                    break;
                case MatchResult.Tie:
                    state.TieCount++;
                    CashOut(false, out paidOut);
                    AudioUtils.Play(AudioUtils.Sounds.SfxTie);
                    DialogUtils.ShowInfo(string.Format(Resources.InfoTie, paidOut.ToString("C0")));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }

            state.InProgress = false;
            state.CurrentTurn = null;
            state.BetAmount = 0;
            state.DidPlayerDouble = false;

            CommonUtils.UpdateAchievements(ref state);
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        /// <param name="isUnexpectedReason">Whether or not the reason for ending the game is unexpected (not controlled by the user, eg: crash)</param>
        /// <returns></returns>
        private bool EndGame(bool isUnexpectedReason)
        {
            if (isUnexpectedReason || !state.InProgress)
            {
                state.BankAmount += state.BetAmount;
            }
            else if (state.InProgress)
            {
                if (!DialogUtils.ConfirmChoice(Resources.ConfirmEndGameQuestion))
                {
                    return false;
                }
                else
                {
                    state.BankAmount += state.BetAmount / 2;
                }
            }

            EndMatch(MatchResult.PlayerForfeit);

            while (true)
            {
                if (AppSaveFileUtils.SaveGame(state) || !DialogUtils.ConfirmChoice(Resources.ConfirmRetrySaveQuestion))
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Initializes the game, preparing it for a new match.
        /// </summary>
        private void InitializeGame()
        {
            state.Deck = new CardDeck
            {
                CardImageUriFactory = (card) => $"card_{(int)card.Suit}_{(int)card.Rank}"
            };
            state.Deck?.Initialize();

            state.CurrentTurn = null;

            state.DealerHand = new Hand(PlayerType.Dealer);
            state.PlayerHand = new Hand(PlayerType.Player);
        }

        /// <summary>
        /// Deals a card to a hand.
        /// </summary>
        /// <param name="hand">The hand to which to deal a card.</param>
        /// <param name="rank">FOR DEBUGGING PURPOSES</param>
        /// <exception cref="InvalidOperationException">
        /// If the deck or hand are not initialized, 
        /// or if the deck lacks available cards 
        /// </exception>
        private void DealCard(Hand? hand, Rank? rank = null)
        {
            if (state.Deck == null)
            {
                throw new InvalidOperationException("Deck not initialized");
            }

            if (hand == null)
            {
                throw new InvalidOperationException("Hand not initialized");
            }

            if (!state.Deck.HasNext)
            {
                throw new InvalidOperationException("No more cards!");
            }

            ExecutionTimeUtils.WaitForSeconds(0.4f);
            Card dealt = state.Deck.DealCard(rank);
            hand.AddCard(dealt);
            AudioUtils.Play(AudioUtils.Sounds.SfxCard);
        }

        /// <summary>
        /// Deals the initial cards.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the game is not yet started.</exception>
        private void DealInitialCards()
        {
            if (!state.InProgress)
            {
                throw new InvalidOperationException("Game not started");
            }

            DealCard(state.PlayerHand);
            DealCard(state.DealerHand);
            DealCard(state.PlayerHand);
            DealFakeCardToDealer();

            if (state.PlayerHand?.Sum != 21)
            {
                state.CurrentTurn = PlayerType.Player;
            }
            else
            {
                state.CurrentTurn = PlayerType.Dealer;
                StartDealerTurn();
            }
        }

        /// <summary>
        /// Deal a fake card to the dealer, to simulate the dealer's second card facing down at the start of a round.
        /// </summary>
        private void DealFakeCardToDealer()
        {
            // Delay for a smoother experience 
            ExecutionTimeUtils.WaitForSeconds(0.4f);

            pnlDealerCard2.BackgroundImage = ImageUtils.GetBitmapResource("card_back");
            pnlDealerCard2.Refresh();
            AudioUtils.Play(AudioUtils.Sounds.SfxCard);

            // Delay for a smoother experience 
            ExecutionTimeUtils.WaitForSeconds(0.7f);
        }

        /// <summary>
        /// Deal to the dealer then handle the turn.
        /// </summary>
        private void StartDealerTurn()
        {
            if (!state.InProgress)
            {
                throw new InvalidOperationException("Game not started");
            }

            if (state.CurrentTurn == PlayerType.Player)
            {
                return;
            }

            if (state.CurrentTurn == PlayerType.Dealer)
            {
                // NEUTRAL
                // Will not take into account the player's hand and will always hit on soft 17 or less
                while (state.DealerHand?.IsSoftHandOrLess == true)
                {
                    DealCard(state.DealerHand);
                }

                EndMatch(DetermineMatchOutcome());
            }
        }

        /// <summary>
        /// Deal to the player then handle the turn.
        /// </summary>
        private void DealToPlayer() 
        {
            DealCard(state.PlayerHand);

            if (state.DidPlayerDouble || (!CanPlayerContinue(out bool gameEnded) && !gameEnded))
            {
                state.CurrentTurn = PlayerType.Dealer;
                StartDealerTurn();
            }
        }

        private bool CanPlayerContinue(out bool gameEnded)
        {
            gameEnded = false;
            if (state.PlayerHand?.Sum > 21)
            {
                gameEnded = true;
                EndMatch(MatchResult.PlayerBust);
                return false;
            }
            else if (state.PlayerHand?.Sum == 21)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds an amount to the bet, withdrawing the amount from the bank.
        /// </summary>
        /// <param name="amount">The amount to bet.</param>
        private void AddBet(int amount)
        {
            state.BankAmount -= amount;
            state.BetAmount += amount;

            // Force refresh now before any other UI refresh occurs
            lblBetValue.Refresh();
            lblBankValue.Refresh();
        }

        /// <summary>
        /// Cash out to the player after a win.
        /// </summary>
        /// <param name="isDouble">Whether or not to double the amount paid out.</param>
        /// <param name="amountPaidOut">The amount that was paid out.</param>
        private void CashOut(bool isDouble, out int amountPaidOut)
        {
            amountPaidOut = isDouble ? state.BetAmount * 2 : state.BetAmount;
            state.BankAmount += amountPaidOut;
            state.BetAmount = 0;
        }
        #endregion

        #region UI Update Methods

        /// <summary>
        /// Updates the UI globally.
        /// </summary>
        private void UpdateUI()
        {
            Text = CommonUtils.GetTitle();

            UpdateBetUI();
            UpdateBankUI();
            UpdateWinsUI();
            UpdateLossesUI();
            UpdateTiesUI();
            UpdateTurnUI();
            UpdateInProgressUI();
            UpdateTooltipUI();
            UpdatePlayerHandUI();
            UpdateDealerHandUI();
            UpdateBackgroundUI();
        }

        /// <summary>
        /// Updates the UI according to the active background image.
        /// </summary>
        private void UpdateBackgroundUI()
        {
            BackgroundImage? background = ImageUtils.BackgroundImages
                                                    .SingleOrDefault(x => x.Id == state.ActiveBackgroundId);
            if (background != null)
            {
                groupInfo.ForeColor = background.RecommendedForeColor;
                groupBet.ForeColor = background.RecommendedForeColor;
                groupActions.ForeColor = background.RecommendedForeColor;
                flowPanelDealerCards.ForeColor = background.RecommendedForeColor;
                flowPanelPlayerCards.ForeColor = background.RecommendedForeColor;
                lblPlayerHand.ForeColor = background.RecommendedForeColor;
                lblDealerHand.ForeColor = background.RecommendedForeColor;
            }
        }

        /// <summary>
        /// Updates the actions UI.
        /// </summary>
        private void UpdateActionsUI()
        {
            btnDouble.Enabled = !state.DidPlayerDouble && state.BankAmount - state.BetAmount >= 0 && (state.BetAmount * 2) <= MaximumBetAmount;
            btnHit.Enabled = !state.DidPlayerDouble;
            btnStand.Enabled = !state.DidPlayerDouble;
        }

        /// <summary>
        /// Updates the tooltip UI.
        /// </summary>
        private void UpdateTooltipUI()
        {
            tipBet1.SetToolTip(btnBet1, Resources.TooltipBet1);
            tipBet5.SetToolTip(btnBet5, Resources.TooltipBet5);
            tipBet25.SetToolTip(btnBet25, Resources.TooltipBet25);
            tipBet50.SetToolTip(btnBet50, Resources.TooltipBet50);
            tipBet100.SetToolTip(btnBet100, Resources.TooltipBet100);
            tipBet500.SetToolTip(btnBet500, Resources.TooltipBet500);
            tipDeal.SetToolTip(btnDeal, Resources.TooltipDeal);
            tipHit.SetToolTip(btnHit, Resources.TooltipHit);
            tipStand.SetToolTip(btnStand, Resources.TooltipStand);
            tipDouble.SetToolTip(btnDouble, Resources.TooltipDouble);
            tipExit.SetToolTip(btnExit, Resources.TooltipExitGame);
            tipResetBet.SetToolTip(btnResetBet, Resources.TooltipResetBet);
        }

        /// <summary>
        /// Updates the hand UI for the player.
        /// </summary>
        private void UpdatePlayerHandUI()
        {
            UpdateHandUI(PlayerType.Player);
        }

        /// <summary>
        /// Updates the hand UI for the dealer.
        /// </summary>
        private void UpdateDealerHandUI()
        {
            UpdateHandUI(PlayerType.Dealer);
        }

        /// <summary>
        /// Updates the hand UI for a player type, re-rendering the cards and updating the hand value display.
        /// </summary>
        /// <param name="playerType">The player type for which to update the hand UI.</param>
        private void UpdateHandUI(PlayerType playerType)
        {
            Hand? hand = playerType == PlayerType.Player ? state.PlayerHand : state.DealerHand;
            Label label = playerType == PlayerType.Player ? lblPlayerHand : lblDealerHand;
            Panel[] panels = playerType == PlayerType.Player ? playerCardPanels : dealerCardPanels;

            if (hand == null)
            {
                label.Text = string.Empty;
            }
            else
            {
                string handName = playerType == PlayerType.Player ? Resources.Player : Resources.Dealer;

                string sumDisplay;
                if (hand.IsSumAmbiguous)
                {
                    (int possibleSumA, int possibleSumB) = hand.PossibleSums;
                    sumDisplay = $"{possibleSumA} | {possibleSumB}";
                }
                else
                {
                    sumDisplay = $"{hand.Sum}";
                }

                label.Text = $"{handName}: {sumDisplay}";
            }
            label.Refresh();

            for (int i = 0; i < panels.Length; i++)
            {
                Panel panel = panels[i];
                Card? card = hand?.GetCard(i);

                if (card == null)
                {
                    panel.BackgroundImage = null;
                }
                else
                {
                    ToolTip tooltip = new();
                    tooltip.SetToolTip(panel, card.Name);

                    panel.BackgroundImage = ImageUtils.GetBitmapResource(card.ImageUri ?? "");
                }

                panel.Refresh();
            }
        }

        /// <summary>
        /// Updates the UI for the bet amount.
        /// </summary>
        private void UpdateBetUI()
        {
            lblBetValue.Text = state.BetAmount.ToString("C0");
            btnResetBet.Enabled = state.BetAmount > 0;
            btnBet1.Enabled = state.BankAmount >= 1 && (state.BetAmount + 1) <= MaximumBetAmount;
            btnBet5.Enabled = state.BankAmount >= 5 && (state.BetAmount + 5) <= MaximumBetAmount;
            btnBet25.Enabled = state.BankAmount >= 25 && (state.BetAmount + 25) <= MaximumBetAmount;
            btnBet50.Enabled = state.BankAmount >= 50 && (state.BetAmount + 50) <= MaximumBetAmount;
            btnBet100.Enabled = state.BankAmount >= 100 && (state.BetAmount + 100) <= MaximumBetAmount;
            btnBet500.Enabled = state.BankAmount >= 500 && (state.BetAmount + 500) <= MaximumBetAmount;
        }

        /// <summary>
        /// Updates the UI for the win count.
        /// </summary>
        private void UpdateWinsUI()
        {
            lblWinsValue.Text = state.WinCount.ToString();
        }

        /// <summary>
        /// Updates the UI for the loss count.
        /// </summary>
        private void UpdateLossesUI()
        {
            lblLossesValue.Text = state.LossCount.ToString();
        }

        /// <summary>
        /// Updates the UI for the tie count.
        /// </summary>
        private void UpdateTiesUI()
        {
            lblTiesValue.Text = state.LossCount.ToString();
        }

        /// <summary>
        /// Updates the UI for the in progress status.
        /// </summary>
        private void UpdateInProgressUI()
        {
            btnDeal.Visible = !state.InProgress;
            btnResetBet.Visible = !state.InProgress;

            groupActions.Visible = state.InProgress;
            groupBet.Visible = !state.InProgress;

            flowPanelDealerCards.Visible = state.InProgress;
            flowPanelPlayerCards.Visible = state.InProgress;

            lblDealerHand.Visible = state.InProgress;
            lblPlayerHand.Visible = state.InProgress;
        }

        /// <summary>
        /// Updates the UI for the current turn.
        /// </summary>
        private void UpdateTurnUI()
        {
            lblTurnValue.Text = state.CurrentTurn == null ? "n/a" : state.CurrentTurn.ToString();
            groupActions.Enabled = state.CurrentTurn == PlayerType.Player;
        }

        /// <summary>
        /// Updates the UI for the bank amount.
        /// </summary>
        private void UpdateBankUI()
        {
            lblBankValue.Text = state.BankAmount.ToString("C0");

            if (state.BankAmount == 0 && state.BetAmount == 0)
            {
                DialogUtils.ShowWarning(Resources.WarningNoMoreFunds);
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles a property change in the game state.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void State_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            string? propName = e.PropertyName;
            if (propName == null)
            {
                return;
            }

            // Bank
            if (propName == nameof(state.BankAmount))
            {
                UpdateBankUI();
            }
            // Turn
            else if (propName == nameof(state.CurrentTurn))
            {
                UpdateTurnUI();
            }
            // Bet
            else if (propName == nameof(state.BetAmount))
            {
                UpdateBetUI();
                UpdateActionsUI();
            }
            // Wins
            else if (propName == nameof(state.WinCount))
            {
                UpdateWinsUI();
            }
            // Losses
            else if (propName == nameof(state.LossCount))
            {
                UpdateLossesUI();
            }
            // Ties
            else if (propName == nameof(state.TieCount))
            {
                UpdateTiesUI();
            }
            // In Progress
            else if (propName == nameof(state.InProgress))
            {
                UpdateInProgressUI();
            }
            // Player Hand
            else if (propName == nameof(state.PlayerHand))
            {
                UpdatePlayerHandUI();
            }
            // Dealer Hand
            else if (propName == nameof(state.DealerHand))
            {
                UpdateDealerHandUI();
            }
            else if (propName == nameof(state.DidPlayerDouble))
            {
                UpdateActionsUI();
            }
        }

        /// <summary>
        /// Handles the click of a betting button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnBet_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxBet);

            Button btnBet = (Button)sender;

            if (btnBet.Name == btnBet1.Name)
            {
                AddBet(1);
            }
            else if (btnBet.Name == btnBet5.Name)
            {
                AddBet(5);
            }
            else if (btnBet.Name == btnBet25.Name)
            {
                AddBet(25);
            }
            else if (btnBet.Name == btnBet50.Name)
            {
                AddBet(50);
            }
            else if (btnBet.Name == btnBet100.Name)
            {
                AddBet(100);
            }
            else if (btnBet.Name == btnBet500.Name)
            {
                AddBet(500);
            }
        }

        /// <summary>
        /// Handles the click of the deal button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnDeal_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            if (state.BetAmount == 0)
            {
                DialogUtils.ShowValidationError(Resources.BetAmount);
                return;
            }

            StartMatch();
        }

        /// <summary>
        /// Handles the click of the exit button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            Close();
        }

        /// <summary>
        /// Handles the closing of the game form (when attempting to close).
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !EndGame(e.CloseReason != CloseReason.UserClosing);
        }

        /// <summary>
        /// Handles the click of the hit button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnHit_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            DealToPlayer();
        }

        /// <summary>
        /// Handles the click of the stand button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnStand_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            state.CurrentTurn = PlayerType.Dealer;
            StartDealerTurn();
        }

        /// <summary>
        /// Handles the click of the double button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnDouble_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            AddBet(state.BetAmount);
            state.DidPlayerDouble = true;
            DealToPlayer();
        }

        /// <summary>
        /// Handles the click of the reset bet button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnResetBet_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            CashOut(false, out _);
        }
        #endregion
    }
}
