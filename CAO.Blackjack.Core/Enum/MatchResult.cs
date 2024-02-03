namespace CAO.Blackjack.Core.Enum
{
    /// <summary>
    /// An enumeration of possible Blackjack match results
    /// </summary>
    public enum MatchResult
    {
        /// <summary>
        /// Represents the match result where the dealer busts.
        /// <para>
        /// - The sum of the dealer's hand is over 21
        /// </para>
        /// </summary>
        DealerBust,

        /// <summary>
        /// Represents the match result where the player busts.
        /// <para>
        /// - The sum of the player's hand is over 21
        /// </para>
        /// </summary>
        PlayerBust,

        /// <summary>
        /// Represents the match result where the dealer wins.
        /// <para>
        /// - The sum of the dealer's hand is greater than the sum of the player's hand
        /// </para>
        /// <para>
        /// - The sum of the dealer's hand is lesser or equal to 21
        /// </para>
        /// </summary>
        DealerWin,

        /// <summary>
        /// Represents the match result where the player wins.
        /// <para>
        /// - The sum of the player's hand is greater than the sum of the dealer's hand
        /// </para>
        /// <para>
        /// - The sum of the player's hand is lesser to 21
        /// </para>
        /// </summary>
        PlayerWin,

        /// <summary>
        /// Represents the match result where the player wins with a blackjack (21).
        /// <para>
        /// <para>
        /// - The sum of the player's hand is greater than the sum of the dealer's hand
        /// </para>
        /// <para>
        /// - The sum of the player's hand is equal to 21
        /// </para>
        /// </summary>
        /// </summary>
        PlayerWinBlackjack,

        /// <summary>
        /// Represents the match result where the player and the dealer have a tie.
        /// <para>
        /// - The sum of the player's hand is equal to the sum of the dealer's hand
        /// </para>
        /// <para>
        /// - Both the sum of the player's hand and the sum of the dealer's hand are lesser or equal to 21
        /// </para>
        /// </summary>
        Tie,

        /// <summary>
        /// Represents the match result where the player forfeit the match.
        /// </summary>
        PlayerForfeit,
    }
}
