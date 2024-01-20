using CAO.Blackjack.Core.Data;
using CAO.Blackjack.Forms.Models;
using CAO.Blackjack.Forms.Properties;
using CAO.Blackjack.Forms.Utils;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// The application's shop form, used to purchase unlockables.
    /// </summary>
    public partial class FormShop : Form
    {
        /// <summary>
        /// The internal game state.
        /// </summary>
        private GameState state = CommonUtils.CreateNewGameState();

        /// <summary>
        /// Instantiate a new shop form.
        /// </summary>
        public FormShop()
        {
            InitializeComponent();
            this.EnableDoubleBuffered(true);
            LoadGameState();
            UpdateUI();
        }

        /// <summary>
        /// Load the game state.
        /// </summary>
        private void LoadGameState()
        {
            GameState? loadedState = CommonUtils.LoadGameSaveFile();
            CommonUtils.TryCopyGameStateToCurrentState(ref state, loadedState);
            state.PropertyChanged += State_PropertyChanged;
        }

        /// <summary>
        /// Handle a state property change.
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

            if (propName == nameof(state.BankAmount))
            {
                UpdateBankUI();
            }
            else if (propName == nameof(state.PurchasedBackgroundIds))
            {
                UpdateBackgroundUI();
            }
            else if (propName == nameof(state.ActiveBackgroundId))
            {
                UpdateBackgroundUI();
            }

        }

        /// <summary>
        /// Update the tooltip UI.
        /// </summary>
        private void UpdateTooltipUI()
        {
            tipExit.SetToolTip(btnExit, Resources.TooltipExitShop);
            tipPurchase.SetToolTip(btnPurchase, Resources.TooltipPurchaseBackground);
            tipUse.SetToolTip(btnUse, Resources.TooltipUseBackground);
        }

        /// <summary>
        /// Update the UI for the bank amount.
        /// </summary>
        private void UpdateBankUI()
        {
            lblBankValue.Text = state.BankAmount.ToString("C0");

            if (state.BankAmount == 0)
            {
                DialogUtils.ShowWarning(Resources.WarningNoMoreFunds);
            }
        }

        /// <summary>
        /// Update the UI globally.
        /// </summary>
        private void UpdateUI()
        {
            Text = CommonUtils.GetTitle();

            UpdateBackgroundUI();
            UpdateBankUI();
            UpdateTooltipUI();
        }

        /// <summary>
        /// Update the UI for the background.
        /// </summary>
        private void UpdateBackgroundUI()
        {
            IEnumerable<BackgroundImage> backgroundImages = ImageUtils.BackgroundImages.Select(x =>
            {
                if (x.IsLocked
                    && state.PurchasedBackgroundIds != null
                    && state.PurchasedBackgroundIds.Contains(x.Id))
                {
                    x.IsLocked = false;
                }

                return x;
            });

            listBackgrounds.Items.Clear();
            listBackgrounds.Items.AddRange(backgroundImages.Select(
                img => new ListViewItem(img.ToString())
                {
                    ForeColor = GetBackgroundImageForeColor(img),
                    Tag = img.Id,
                }).ToArray()
            );
            
            btnPurchase.Enabled = false;
            btnUse.Enabled = false;
        }

        /// <summary>
        /// Gets the fore color of a background image depending on the game state.
        /// </summary>
        /// <param name="img">The background image for which to get the fore color.</param>
        /// <returns>The fore color of the background image.</returns>
        private Color GetBackgroundImageForeColor(BackgroundImage img)
        {
            if (img.IsLocked)
            {
                // has enough money to purchase
                return state.BankAmount >= img.Price
                    ? Color.LimeGreen
                    : Color.Red;
            }
            else
            {
                // is active
                return state.ActiveBackgroundId == img.Id
                    ? Color.White
                    : Color.Gray;
            }
        }

        /// <summary>
        /// Exit the shop screen.
        /// </summary>
        private void ExitShop()
        {
            while (true)
            {
                if (AppSaveFileUtils.SaveGame(state) || !DialogUtils.ConfirmChoice(Resources.ConfirmRetrySaveQuestion))
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Handle the click of the exit button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            Close();
        }

        /// <summary>
        /// Handle the shop form closing (before it closes).
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void FormShop_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitShop();
        }

        /// <summary>
        /// Handles the change of the selected index in the background list.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void ListBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem? selectedItem = null;
            foreach (ListViewItem item in listBackgrounds.Items)
            {
                if (item.Selected)
                {
                    selectedItem = item;
                    break;
                }
            };

            if (selectedItem == null)
            {
                btnPurchase.Enabled = false;
                btnUse.Enabled = false;
                return;
            }

            AudioUtils.Play(AudioUtils.Sounds.SfxCard);

            BackgroundImage? image = ImageUtils.BackgroundImages
                                                .SingleOrDefault(x => x.Id == (string)selectedItem.Tag);
            if (image == null)
            {
                return;
            }

            btnPurchase.Enabled = image.IsLocked && state.BankAmount >= image.Price;

            if ((string)selectedItem.Tag == ImageUtils.DefaultBackgroundId)
            {
                btnUse.Enabled = state.ActiveBackgroundId != ImageUtils.DefaultBackgroundId;
            }
            else
            {
                btnUse.Enabled = state.ActiveBackgroundId != image.Id
                    && (!image.IsLocked || (state?.PurchasedBackgroundIds?
                                                  .Contains(image.Id) ?? false));
            }
        }

        /// <summary>
        /// Handles the click of the purchase button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            ListViewItem? selectedItem = listBackgrounds.SelectedItems[0];

            BackgroundImage? image = ImageUtils.BackgroundImages
                                               .SingleOrDefault(x => x.Id == (string)selectedItem.Tag);

            if (image == null)
            {
                return;
            }

            if (state.BankAmount < image.Price)
            {
                DialogUtils.ShowWarning(Resources.WarningInsufficientBank);
            }
            else
            {
                AudioUtils.Play(AudioUtils.Sounds.SfxBet);
                state.BankAmount -= image.Price;
                state.AddPurchasedBackground(image.Id);
            }
        }

        /// <summary>
        /// Handles the click of the use button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnUse_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            ListViewItem? selectedItem = listBackgrounds.SelectedItems[0];

            BackgroundImage? image = ImageUtils.BackgroundImages
                                               .SingleOrDefault(x => x.Id == (string)selectedItem.Tag);
            if (image == null)
            {
                return;
            }

            state.ActiveBackgroundId = image.Id;
        }
    }
}
