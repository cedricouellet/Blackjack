using CAO.Blackjack.Forms.Properties;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// Utility methods for operating on window dialogs
    /// </summary>
    public static class DialogUtils
    {
        /// <summary>
        /// Displays a validation error prompt for a field
        /// </summary>
        /// <param name="fieldName">The name of the field that was invalidated</param>
        public static void ShowValidationError(string fieldName)
        {
            string message = string.Format(Resources.ErrorValidationRequiredField, fieldName);
            MessageBox.Show(message, Resources.ErrorValidationCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays a warning prompt
        /// </summary>
        /// <param name="warningText">The warning text to display</param>
        public static void ShowWarning(string warningText)
        {
            MessageBox.Show(warningText, Resources.WarningCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Displays an information prompt.
        /// </summary>
        /// <param name="infoText">The information text to display.</param>
        /// <param name="customCaption">The custom caption to use, replacing the default information caption.</param>
        public static void ShowInfo(string infoText, string? customCaption = null)
        {
            MessageBox.Show(infoText, customCaption ?? Resources.InfoCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays a confirmation prompt and returns the choice that was made (Yes = true, No = false)
        /// </summary>
        /// <param name="questionText">The text to display, formulated as a question</param>
        /// <returns></returns>
        public static bool ConfirmChoice(string questionText)
        {
            return MessageBox.Show(questionText, Resources.ConfirmCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
