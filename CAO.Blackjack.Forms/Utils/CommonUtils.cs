using CAO.Blackjack.Core.Data;
using CAO.Blackjack.Core.Models;
using CAO.Blackjack.Core.Utils;
using CAO.Blackjack.Forms.Properties;

namespace CAO.Blackjack.Forms.Utils
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

            if (loadedState == null)
            {
                return null;
            }

            loadedState.ActiveBackgroundId ??= ImageUtils.DefaultBackgroundId;

            UpdateAchievements(ref loadedState);

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

            if (!VersionUtils.DetermineVersionIsCompatible(currentState.GameVersion, loadedState.GameVersion))
            {
                DialogUtils.ShowWarning(Resources.WarningIncompatibleVersionSaveFile);
                return;
            }

            currentState.WinCount = loadedState.WinCount;
            currentState.LossCount = loadedState.LossCount;
            currentState.TieCount = loadedState.TieCount;
            currentState.BankAmount = loadedState.BankAmount;
            currentState.ActiveBackgroundId = loadedState.ActiveBackgroundId;
            currentState.PurchasedBackgroundIds = loadedState.PurchasedBackgroundIds;
            currentState.UnlockedAchievementIds = loadedState.UnlockedAchievementIds;
        }

        /// <summary>
        /// Update a game state's achievement, checking their conditions as needed.
        /// </summary>
        /// <param name="state">The game state for which to update achievements</param>
        public static void UpdateAchievements(ref GameState state)
        {
            if (state == null)
            {
                return;
            }

            foreach (Achievement achievement in AchievementUtils.Achievements)
            {
                if (state.UnlockedAchievementIds.Contains(achievement.Id))
                {
                    continue;
                }

                if (achievement.DoesSatisfyCondition(state))
                {
                    state.AddAchievement(achievement.Id);
                }
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
