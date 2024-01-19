using CAO.Blackjack.Core;
using CAO.Blackjack.Forms.Properties;
using System.Runtime.CompilerServices;

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
            UpdateBackgroundUI();
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
            lblBankValue.Text = $"{state.BankAmount}$";

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
            IEnumerable<BackgroundImage> backgroundImages = ImageUtils.Backgrounds.Select(x =>
            {
                if (x.IsLocked)
                {
                    if (state.PurchasedBackgroundIds != null && state.PurchasedBackgroundIds.Contains(x.Id))
                    {
                        x.IsLocked = false;
                    }
                }

                return x;
            });

            listBackgrounds.Items.Clear();
            foreach (var img in backgroundImages)
            {
                listBackgrounds.Items.Add(new ListViewItem(img.ToString())
                {
                    ForeColor = Color.White,
                    Tag = img.Id,
                });
            }

            btnPurchase.Enabled = false;
            btnUse.Enabled = false;
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
            AudioUtils.Play(Resources.sfx_button_click);
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
        private void listBackgrounds_SelectedIndexChanged(object sender, EventArgs e)
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

            AudioUtils.Play(Resources.sfx_card);

            BackgroundImage? image = ImageUtils.Backgrounds.SingleOrDefault(x => x.Id == (string)selectedItem.Tag);
            if (image == null)
            {
                return;
            }

            btnPurchase.Enabled = image.IsLocked;

            if ((string)selectedItem.Tag == ImageUtils.DefaultBackgroundId)
            {
                btnUse.Enabled = state?.ActiveBackgroundId != ImageUtils.DefaultBackgroundId;
            }
            else
            {
                btnUse.Enabled = state?.ActiveBackgroundId != image.Id && (!image.IsLocked || (state?.PurchasedBackgroundIds?.Contains(image.Id) ?? false));
            }
        }

        /// <summary>
        /// Handles the click of the purchase button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);
            ListViewItem? selectedItem = listBackgrounds.SelectedItems[0];
            BackgroundImage? image = ImageUtils.Backgrounds.SingleOrDefault(x => x.Id == (string)selectedItem.Tag);

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
                AudioUtils.Play(Resources.sfx_bet);
                state.BankAmount -= image.Price;
                state.AddPurchasedBackground(image.Id);
            }
        }

        /// <summary>
        /// Handles the click of the use button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void btnUse_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);
            ListViewItem? selectedItem = listBackgrounds.SelectedItems[0];
            BackgroundImage? image = ImageUtils.Backgrounds.SingleOrDefault(x => x.Id == (string)selectedItem.Tag);
            if (image == null)
            {
                return;
            }

            state.ActiveBackgroundId = image.Id;
        }
    }
}
