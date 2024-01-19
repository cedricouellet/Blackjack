namespace CAO.Blackjack.Core.Utils
{
    /// <summary>
    /// Utility methods for operating on execution time
    /// </summary>
    public static class ExecutionTimeUtils
    {
        /// <summary>
        /// Pause the execution of the current thread for a specified number of seconds
        /// </summary>
        /// <param name="durationInSeconds">The duration for which to pause the execution of the current thread, in seconds</param>
        public static void WaitForSeconds(float durationInSeconds)
        {
            Thread.Sleep((int)(durationInSeconds * 1000));
        }
    }
}
