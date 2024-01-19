using CAO.Blackjack.Core;
using CAO.Blackjack.Forms.Properties;

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
        private const int MaximumBetAmount = 2000;

        #endregion

        #region Private Properties
        /// <summary>
        /// Gets the dealer card UI panels
        /// </summary>
        private Panel[] DealerCardPanels => new Panel[]
{
            pnlDealerCard1,
            pnlDealerCard2,
            pnlDealerCard3,
            pnlDealerCard4,
            pnlDealerCard5,
            pnlDealerCard6,
            pnlDealerCard7,
            pnlDealerCard8,
            pnlDealerCard9,
            pnlDealerCard10,
            pnlDealerCard11,
};

        /// <summary>
        /// Gets the player card UI panels
        /// </summary>
        private Panel[] PlayerCardPanels => new Panel[]
        {
            pnlPlayerCard1,
            pnlPlayerCard2,
            pnlPlayerCard3,
            pnlPlayerCard4,
            pnlPlayerCard5,
            pnlPlayerCard6,
            pnlPlayerCard7,
            pnlPlayerCard8,
            pnlPlayerCard9,
            pnlPlayerCard10,
            pnlPlayerCard11,
        };
        #endregion

        #region Private Members

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
            InitializeGame();

            state.InProgress = true;

            AudioUtils.Play(Resources.sfx_shuffle);
            ExecutionTimeUtils.WaitForSeconds(2.5f);
            state.Deck?.Shuffle();

            StartFirstTurn();
        }

        /// <summary>
        /// Ends the current match.
        /// </summary>
        /// <param name="result">The result of the match.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the result was unhandled due to an unknown value.</exception>
        private void EndMatch(MatchResult? result)
        {
            int paidOut = 0;
            switch (result)
            {
                case null:
                    break;
                case MatchResult.PlayerForfeit:
                    AudioUtils.Play(Resources.sfx_exit);
                    break;
                case MatchResult.PlayerBust:
                    state.LossCount++;
                    AudioUtils.Play(Resources.sfx_lose);
                    Card? wouldBeNextCard = state.Deck?.DealCard();
                    DialogUtils.ShowInfo(string.Format(Resources.InfoPlayerBust, wouldBeNextCard?.Name ?? "n/a", wouldBeNextCard?.Value));
                    break;
                case MatchResult.DealerBust:
                    state.WinCount++;
                    CashOut(true, out paidOut);
                    AudioUtils.Play(Resources.sfx_win);
                    DialogUtils.ShowInfo(string.Format(Resources.InfoDealerBust, paidOut));
                    break;
                case MatchResult.PlayerWin:
                    state.WinCount++;
                    CashOut(true, out paidOut);
                    AudioUtils.Play(Resources.sfx_win);
                    DialogUtils.ShowInfo(string.Format(Resources.InfoPlayerWin, paidOut));
                    break;
                case MatchResult.DealerWin:
                    state.LossCount++;
                    AudioUtils.Play(Resources.sfx_lose);
                    DialogUtils.ShowInfo(Resources.InfoDealerWin);
                    break;
                case MatchResult.Tie:
                    state.TieCount++;
                    CashOut(false, out paidOut);
                    AudioUtils.Play(Resources.sfx_tie);
                    DialogUtils.ShowInfo(string.Format(Resources.InfoTie, paidOut));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result));
            }

            state.InProgress = false;
            state.CurrentTurn = null;
            state.BetAmount = 0;
            state.PlayerDoubled = false;
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
            state.Deck = new CardDeck();
            state.Deck.CardImageUriFactory = (card) => $"card_{(int)card.Suit}_{(int)card.Rank}";
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

            ExecutionTimeUtils.WaitForSeconds(0.7f);
            Card dealt = state.Deck.DealCard(rank);
            hand.AddCard(dealt);
            AudioUtils.Play(Resources.sfx_card);
        }

        /// <summary>
        /// Makes the first turn in the game.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the game is not yet started.</exception>
        private void StartFirstTurn()
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
                StartDealerTurn(false, true);
            }

        }

        /// <summary>
        /// Deal a fake card to the dealer, to simulate the dealer's second card facing down at the start of a round.
        /// </summary>
        private void DealFakeCardToDealer()
        {
            // Delay for a smoother experience 
            ExecutionTimeUtils.WaitForSeconds(0.7f);

            pnlDealerCard2.BackgroundImage = ImageUtils.GetBitmapResource("card_back");
            pnlDealerCard2.Refresh();
            AudioUtils.Play(Resources.sfx_card);

            // Delay for a smoother experience 
            ExecutionTimeUtils.WaitForSeconds(1f);
        }

        /// <summary>
        /// Deal to the dealer then handle the turn.
        /// </summary>
        private void StartDealerTurn(bool canKeepHitting, bool nextCardEndsGame = false)
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
                DealCard(state.DealerHand);

                if (nextCardEndsGame)
                {
                    ExecutionTimeUtils.WaitForSeconds(1f);
                    HandleEndOfTurn(true);
                    return;
                }

                if (canKeepHitting && state.DealerHand?.Cards.Count() > 1)
                {
                    // Stand if soft 17 or less
                    while (state.DealerHand?.IsSoftHandOrLess == true)
                    {
                        DealCard(state.DealerHand);
                    }
                }

                if (!HandleEndOfTurn(state.PlayerDoubled))
                {
                    state.CurrentTurn = PlayerType.Player;
                }

            }
        }

        /// <summary>
        /// Deal to the player then handle the turn.
        /// </summary>
        private void DealToPlayer() 
        {
            DealCard(state.PlayerHand);

            if (!HandleEndOfTurn(false))
            {
                state.CurrentTurn = PlayerType.Dealer;
                StartDealerTurn(true, state?.PlayerHand?.Sum == 21);
            }
        }

        /// <summary>
        /// Handles the end of a turn.
        /// </summary>
        /// <param name="isLastTurn">Whether or not the turn that was made should be cause the end of the game.</param>
        /// <returns>True if the end of the turn ended the game, otherwise false.</returns>
        private bool HandleEndOfTurn(bool isLastTurn)
        {
            switch (state.CurrentTurn)
            {
                case PlayerType.Player:
                    if (state.PlayerHand?.Sum > 21)
                    {
                        EndMatch(MatchResult.PlayerBust);
                        return true;
                    }
                    else if (state.PlayerHand?.Sum == 21 && state.DealerHand?.Sum == 21)
                    {
                        EndMatch(MatchResult.Tie);
                        return true;
                    }

                    return false;
                case PlayerType.Dealer:
                    if (state.DealerHand?.Sum > 21)
                    {
                        EndMatch(MatchResult.DealerBust);
                        return true;
                    }

                    if (state.DealerHand?.Sum == 21 && state.PlayerHand?.Sum < 21)
                    {
                        EndMatch(MatchResult.DealerWin);
                        return true;
                    }

                    if (isLastTurn)
                    {
                        if (state.DealerHand?.Sum == state.PlayerHand?.Sum)
                        {
                            EndMatch(MatchResult.Tie);
                            return true;
                        }
                        else if (state.DealerHand?.Sum > state.PlayerHand?.Sum)
                        {
                            EndMatch(MatchResult.DealerWin);
                            return true;
                        }

                        EndMatch(MatchResult.PlayerWin);
                        return true;
                    }

                    if (state.DealerHand?.Sum > 21)
                    {
                        EndMatch(MatchResult.DealerBust);
                        return true;
                    }
                    else if (state.PlayerHand?.Sum == 21 && state.DealerHand?.Sum == 21)
                    {
                        EndMatch(MatchResult.Tie);
                        return true;
                    }

                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Adds an amount to the bet, withdrawing the amount from the bank.
        /// </summary>
        /// <param name="amount">The amount to bet.</param>
        private void AddBet(int amount)
        {
            state.BankAmount -= amount;
            state.BetAmount += amount;
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
        }

        /// <summary>
        /// Updates the actions UI.
        /// </summary>
        private void UpdateActionsUI()
        {
            btnDouble.Enabled = !state.PlayerDoubled && state.BankAmount - state.BetAmount >= 0 && (state.BetAmount * 2) <= MaximumBetAmount;
            btnHit.Enabled = !state.PlayerDoubled;
            btnStand.Enabled = !state.PlayerDoubled;
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
            GroupBox groupCards = playerType == PlayerType.Player ? groupPlayerCards : groupDealerCards;
            Panel[] panels = playerType == PlayerType.Player ? PlayerCardPanels : DealerCardPanels;

            if (hand == null)
            {
                groupCards.Text = string.Empty;
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

                groupCards.Text = $"{handName}: {sumDisplay}";
            }

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
                    ToolTip tooltip = new ToolTip();
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
            lblBetValue.Text = $"{state.BetAmount}$";
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

            groupDealerCards.Visible = state.InProgress;
            if (groupDealerCards.Visible)
            {
                groupDealerCards.Refresh();
            }
            
            groupPlayerCards.Visible = state.InProgress;
            if (groupPlayerCards.Visible)
            {
                groupPlayerCards.Refresh();
            }
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
            lblBankValue.Text = $"{state.BankAmount}$";

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
            else if (propName == nameof(state.PlayerDoubled))
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
            AudioUtils.Play(Resources.sfx_bet);

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
            AudioUtils.Play(Resources.sfx_button_click);

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
            AudioUtils.Play(Resources.sfx_button_click);
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
            AudioUtils.Play(Resources.sfx_button_click);
            DealToPlayer();
        }

        /// <summary>
        /// Handles the click of the stand button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnStand_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);
            state.CurrentTurn = PlayerType.Dealer;
            state.PlayerDoubled = true;
            StartDealerTurn(true);
        }

        /// <summary>
        /// Handles the click of the double button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnDouble_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);
            AddBet(state.BetAmount * 2);

            state.PlayerDoubled = true;
            
            DealToPlayer();
        }

        /// <summary>
        /// Handles the click of the reset bet button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnResetBet_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);
            CashOut(false, out _);
        }
        #endregion
    }
}
