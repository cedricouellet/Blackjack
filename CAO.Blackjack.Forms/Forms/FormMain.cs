using CAO.Blackjack.Forms.Utils;

namespace CAO.Blackjack.Forms.Forms
{
    /// <summary>
    /// The main application form.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// The menu form.
        /// </summary>
        private readonly FormMenu? formMenu;

        /// <summary>
        /// Instanciate a new form.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            Text = CommonUtils.GetTitle();
            this.EnableDoubleBuffered(true);

            formMenu = new FormMenu();
            formMenu.MdiParent = this;
            formMenu.FormClosed += FormMenu_FormClosed;
            formMenu.Show();
        }

        /// <summary>
        /// Handles the closing of the menu form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void FormMenu_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the closing of the main form.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Form child in MdiChildren)
            {
                child.MdiParent = null;
                child.Close();
            }
        }
    }
}
