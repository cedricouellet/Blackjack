using CAO.Blackjack.Forms.Forms;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// The main class for the application
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}