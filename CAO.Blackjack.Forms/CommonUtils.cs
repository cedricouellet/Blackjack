using CAO.Blackjack.Core;
using CAO.Blackjack.Forms.Properties;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// Utility methods common to most forms in the application.
    /// </summary>
    public static class CommonUtils
    {
        /// <summary>
        /// The default starting bank amount.
        /// </summary>
        private const int DefaultBankAmount = 500;

        /// <summary>
        /// Gets the application title.
        /// </summary>
        public static string GetTitle()
        {
            return $"{Application.ProductName} {Application.ProductVersion}";
        }

        /// <summary>
        /// Load the game state save, including a retry confirmation if it fails.
        /// </summary>
        /// <returns>The game state if found, otherwise null.</returns>
        public static GameState? LoadGameSaveFile()
        {
            GameState? loadedState = null;
            if (AppSaveFileUtils.SaveFileExists)
            {
                while (true)
                {
                    if (AppSaveFileUtils.LoadGame(out loadedState) || !DialogUtils.ConfirmChoice(Resources.ConfirmRetryLoadQuestion))
                    {
                        break;
                    }
                }
            }

            return loadedState;
        }

        /// <summary>
        /// Try to copy the loaded game state's values into the current game state.
        /// </summary>
        /// <param name="currentState">The current game state.</param>
        /// <param name="loadedState">The loaded game state.</param>
        public static void TryCopyGameStateToCurrentState(ref GameState currentState, GameState? loadedState)
        {
            if (loadedState == null)
            {
                return;
            }

            if (VersionUtils.DetermineVersionIsCompatible(currentState.GameVersion, loadedState.GameVersion))
            {
                currentState.WinCount = loadedState.WinCount;
                currentState.LossCount = loadedState.LossCount;
                currentState.TieCount = loadedState.TieCount;
                currentState.BankAmount = loadedState.BankAmount;
                currentState.ActiveBackgroundId = loadedState.ActiveBackgroundId;
                currentState.PurchasedBackgroundIds = loadedState.PurchasedBackgroundIds;

                if (currentState.ActiveBackgroundId == null)
                {
                    currentState.ActiveBackgroundId = ImageUtils.DefaultBackgroundId;
                }
            }
            else
            {
                DialogUtils.ShowWarning(Resources.WarningIncompatibleVersionSaveFile);
            }
        }

        /// <summary>
        /// Create a new game state
        /// </summary>
        /// <returns>The game state that was created.</returns>
        public static GameState CreateNewGameState()
        {
            return new GameState()
            {
                GameVersion = Application.ProductVersion,
                BankAmount = DefaultBankAmount,
                ActiveBackgroundId = ImageUtils.DefaultBackgroundId,
        };
        }
    }
}
