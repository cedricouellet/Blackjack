using CAO.Blackjack.Core.Enum;

namespace CAO.Blackjack.Core.Models
{
    /// <summary>
    /// A playing card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets the rank of the card
        /// </summary>
        public Rank Rank { get; private set; }

        /// <summary>
        /// Gets the suit of the card
        /// </summary>
        public Suit Suit { get; private set; }

        /// <summary>
        /// Gets or sets the card's image URI
        /// </summary>
        public string? ImageUri { get; set; }

        /// <summary>
        /// Gets the card's numeric value
        /// </summary>
        public int Value => Rank.GetValue();

        /// <summary>
        /// Gets the display name of the card
        /// </summary>
        public string Name => $"{Rank} of {Suit} ({Value})";

        /// <summary>
        /// Instantiate a new card
        /// </summary>
        /// <param name="rank">The rank of the card</param>
        /// <param name="suit">The suit of the card</param>
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        /// <summary>
        /// Gets the string representation of the card
        /// </summary>
        /// <returns>The string representation of the card</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
