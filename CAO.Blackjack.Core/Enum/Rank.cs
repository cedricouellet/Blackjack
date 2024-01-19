namespace CAO.Blackjack.Core.Enum
{
    /// <summary>
    /// An enumeration of possible card ranks and their values
    /// <para>
    /// - In Blackjack, the perceived value of an Ace can change upon evaluation of a hand's sum (can be equal to 1 or 11)
    /// </para>
    /// <para>
    /// - In Blackjack, the perceived value of the Jack, Queen and King are always equal to 10
    /// </para>
    /// </summary>
    public enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }

    /// <summary>
    /// Extension methods for the Rank enumeration.
    /// </summary>
    public static class RankExtensions
    {
        /// <summary>
        /// Gets the numeric value of a rank
        /// <para>
        /// - Does not take into account the Ace, as this should be done upon evaluation of the hand's sum 
        /// </para>
        /// </summary>
        /// <param name="rank">The rank for which to evaluate the value.</param>
        /// <returns>The numeic value of the rank</returns>
        public static int GetValue(this Rank rank)
        {
            return rank switch
            {
                Rank.Jack => 10,
                Rank.Queen => 10,
                Rank.King => 10,
                _ => (int)rank
            };
        }
    }
}
