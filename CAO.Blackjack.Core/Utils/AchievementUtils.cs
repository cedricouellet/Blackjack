using CAO.Blackjack.Core.Models;

namespace CAO.Blackjack.Core.Utils
{
    /// <summary>
    /// Utility methods for operating on achievements.
    /// </summary>
    public static class AchievementUtils
    {
        /// <summary>
        /// The available achievements.
        /// </summary>
        public static readonly IEnumerable<Achievement> Achievements = new Achievement[]
        {
            new("bank_1k", "Feeling Like A Thousand Bucks", $"Obtain {1000:C0}", (state) => state.BankAmount >= 1000),
            new("bank_2.5k", "Getting There", $"Obtain {2500:C0}", (state) => state.BankAmount >= 2500),
            new("bank_5k", "The House (almost) Always Wins", $"Obtain {5000:C0}", (state) => state.BankAmount >= 5000),
            new("bank_7.5k", "Ok, Stop Cheating", $"Obtain {7500:C0}", (state) => state.BankAmount >= 7500),
            new("bank_10k", "I Said Stop", $"Obtain {10000:C0}", (state) => state.BankAmount >= 10000),
            new("bank_20k", "Seriously?", $"Obtain {20000:C0}", (state) => state.BankAmount >= 20000),
            new("winner_1", "Lucky 7", "Win 7 matches", (state) => state.WinCount >= 7),
            new("winner_2", "Are You Counting Cards?", "Win 50 matches", (state) => state.WinCount >= 50),
            new("winner_3", "Sjuttiosju (seventy-seven)", "Win 77 matches", (state) => state.WinCount >= 77),
            new("winner_4", "I'm The Captain Now", "Win 100 Matches", (state) => state.WinCount >= 100),
            new("loser_1", "Totally Not Addicted", "Lose 10 matches", (state) => state.LossCount >= 10),
            new("loser_2", "Divorced", "Lose 25 matches", (state) => state.LossCount >= 25),
            new("loser_3", "Just Quit Already", "Lose 50 matches", (state) => state.LossCount >= 50),
            new("loser_4", "Bankrupt", "Lose 100 matches", (state) => state.LossCount >= 100),
            new("tie_1", "Suit & Tie", "Get 10 ties", (state) => state.TieCount >= 10),
            new("tie_2", "Perfectly Balanced", "Get 50 ties", (state) => state.TieCount >= 50),
            new("background_1", "Fortnite Skins are Better", "Purchase a background", (state) => state.PurchasedBackgroundIds.Count() >= 2),
            new("background_2", "Spending Addiction", "Purchase 5 backgrounds", (state) => state.PurchasedBackgroundIds.Count() >= 6),
            new("background_3", "Art Collector", "Purchase 10 backgrounds", (state) => state.PurchasedBackgroundIds.Count() >= 11),
            new("first_achievement", "Achievement Unlocked!", "Unlock your first achievement", (state) => state.UnlockedAchievementIds.Any()),
        };
    }
}