using System.Reflection;

namespace CAO.Blackjack.Forms.Extension
{
    /// <summary>
    /// Extensions for controls inheriting the base Control class.
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Set the DoubleBuffered property of a control to the specified value.
        /// </summary>
        /// <param name="control">The control on which to set the DoubleBuffered property.</param>
        /// <param name="enabled">Whether or not to enable the DoubleBuffered property.</param>
        public static void SetDoubleBuffered(this Control control, bool enabled)
        {
            PropertyInfo? property = control.GetType()
                                  .GetProperty(
                                    "DoubleBuffered", 
                                    BindingFlags.Instance | BindingFlags.NonPublic);

            property?.SetValue(control, enabled, null);
        }
    }
}
