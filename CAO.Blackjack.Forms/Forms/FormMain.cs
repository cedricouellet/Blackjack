using CAO.Blackjack.Forms.Properties;
using CAO.Blackjack.Forms.Utils;

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
            this.EnableDoubleBuffered(true);
            UpdateUI();
        }

        /// <summary>
        /// Updates the user interface.
        /// </summary>
        private void UpdateUI()
        {
            Text = CommonUtils.GetTitle();
            tipStart.SetToolTip(btnStart, Resources.TooltipStart);
            tipReset.SetToolTip(btnResetSave, Resources.TooltipResetSave);
            tipAbout.SetToolTip(btnAbout, Resources.TooltipAbout);
            tipShop.SetToolTip(btnShop, Resources.TooltipShop);
            tipExit.SetToolTip(btnExit, Resources.TooltipExitMenu);
            tipAchievements.SetToolTip(btnAchievements, Resources.TooltipAchievements);
            btnResetSave.Visible = AppSaveFileUtils.SaveFileExists;
        }

        /// <summary>
        /// Handles the click of the start button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            Hide();

            FormGame formGame = new()
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
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            if (DialogUtils.ConfirmChoice(Resources.ConfirmDeleteSaveFileQuestion))
            {
                AppSaveFileUtils.DeleteSaveFile();
            }

            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
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
            Show();
        }

        /// <summary>
        /// Handles the click of the about button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            DialogUtils.ShowInfo(Resources.InfoAboutText, customCaption: Resources.InfoAboutCaption);
        }

        /// <summary>
        /// Handles the click of the shop button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnShop_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            Hide();

            FormShop formShop = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location,
            };

            formShop.FormClosed += ChildForm_Closed;
            formShop.Show(this);
        }

        /// <summary>
        /// Handles the click of the achievements button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnAchievements_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            Hide();

            FormAchievements formAchievements = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location,
            };

            formAchievements.FormClosed += ChildForm_Closed;
            formAchievements.Show(this);
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
    }
}
