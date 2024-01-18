using CAO.Blackjack.Core;
using CAO.Blackjack.Forms.Properties;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// The application's main form, acting as the menu screen.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Instantiates a new main form.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            UpdateUI();
        }

        /// <summary>
        /// Updates the user interface.
        /// </summary>
        private void UpdateUI()
        {
            Text = CommonUtils.GetTitle();
            BackgroundImage = ImageUtils.GetBitmapResource("bg_casino");

            tipStart.SetToolTip(btnStart, Resources.TooltipStart);
            tipReset.SetToolTip(btnResetSave, Resources.TooltipResetSave);
            tipAbout.SetToolTip(btnAbout, Resources.TooltipAbout);
            btnResetSave.Visible = AppSaveFileUtils.SaveFileExists;
        }

        /// <summary>
        /// Handles the click of the start button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);

            Hide();

            FormGame formGame = new FormGame()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location,
            };

            formGame.FormClosed += ChildForm_Closed;
            formGame.Show(this);
        }

        /// <summary>
        /// Handles the click of the reset save button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnResetSave_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);

            if (DialogUtils.ConfirmChoice(Resources.ConfirmDeleteSaveFileQuestion))
            {
                AppSaveFileUtils.DeleteSaveFile();
            }

            AudioUtils.Play(Resources.sfx_button_click);
            UpdateUI();
        }

        /// <summary>
        /// Handles the visibility change of the main form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void FormMain_VisibleChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Handles the closing of a child form (after it is closed).
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void ChildForm_Closed(object? sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_exit);
            Show();
        }

        /// <summary>
        /// Handles the click of the about button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);
            DialogUtils.ShowInfo(Resources.InfoAboutText, customCaption: Resources.InfoAboutCaption);
        }

        /// <summary>
        /// Handles the click of the shop button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnShop_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(Resources.sfx_button_click);

            Hide();

            FormShop formShop = new FormShop()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location,
            };

            formShop.FormClosed += ChildForm_Closed;
            formShop.Show(this);
        }
    }


}
