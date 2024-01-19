using CAO.Blackjack.Forms.Extension;

namespace CAO.Blackjack.Forms.Utils
{
    /// <summary>
    /// Utility methods for operating on Forms
    /// </summary>
    public static class FormUtils
    {
        /// <summary>
        /// Enable the DoubleBuffered property on the form (and optionally, its child controls).
        /// </summary>
        /// <param name="form">The form on which to enable the DoubleBuffered property.</param>
        /// <param name="includeChildren">Whether or not to enable the DoubleBuffered property on all child controls.</param>
        public static void EnableDoubleBuffered(this Form form, bool includeChildren)
        {
            form.SetDoubleBuffered(true);

            if (!includeChildren)
            {
                return;
            }

            foreach (Control control in form.Controls)
            {
                control.SetDoubleBuffered(true);
            }
        }
    }
}
