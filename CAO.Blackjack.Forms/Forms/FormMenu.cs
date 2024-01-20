using CAO.Blackjack.Forms.Properties;
using CAO.Blackjack.Forms.Utils;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// The application's menu form.
    /// </summary>
    public partial class FormMenu : Form
    {
        /// <summary>
        /// Instantiates a new main form.
        /// </summary>
        public FormMenu()
        {
            InitializeComponent();
            this.EnableDoubleBuffered(true);
            UpdateUI();
        }

        /// <summary>
        /// Show a form as a child.
        /// </summary>
        /// <param name="form">The form to show as a child</param>
        private void ShowFormAsChild(Form form)
        {
            form.FormClosed += ChildForm_Closed;
            form.MdiParent = MdiParent;
            form.Show();
            Hide();
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

            FormGame formGame = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location,
            };

            ShowFormAsChild(formGame);
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
        /// Handles the visibility change of the menu form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void FormMenu_VisibleChanged(object sender, EventArgs e)
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

            FormShop formShop = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location,
            };

            formShop.FormClosed += ChildForm_Closed;
            formShop.MdiParent = this.MdiParent;
            formShop.Show();
            Hide();
        }

        /// <summary>
        /// Handles the click of the achievements button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnAchievements_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);

            FormAchievements formAchievements = new()
            {
                StartPosition = FormStartPosition.Manual,
                Location = Location,
            };

            formAchievements.FormClosed += ChildForm_Closed;
            formAchievements.MdiParent = this.MdiParent;
            formAchievements.Show();
            Hide();
        }

        /// <summary>
        /// Handles the click of the exit button.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            AudioUtils.Play(AudioUtils.Sounds.SfxButtonClick);
            MdiParent = null;
            Close();
        }

    }
}
