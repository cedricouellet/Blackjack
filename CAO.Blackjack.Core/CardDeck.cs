namespace CAO.Blackjack.Core
{
    /// <summary>
    /// A deck of playing cards
    /// </summary>
    public class CardDeck 
    {
        /// <summary>
        /// The number of cards in a standard playng card deck
        /// </summary>
        public const int InitialCount = 52;

        /// <summary>
        /// Gets or sets the function that obtains a card's image URI 
        /// </summary>
        public Func<Card, string>? CardImageUriFactory { get; set; }

        /// <summary>
        /// The internal stack of cards used by the deck
        /// </summary>
        private Stack<Card> cards = new Stack<Card>();

        /// <summary>
        /// Gets whether or not the deck has any card left 
        /// </summary>
        public bool HasNext => cards.Count > 0;

        /// <summary>
        /// Deals a card, removing it from the deck
        /// </summary>
        /// <param name="rank">FOR DEBUGGING PURPOSES</param>
        /// <returns>The card that was dealt</returns>
        /// <exception cref="Exception">If no cards are left in the deck</exception>
        public Card DealCard(Rank? rank = null)
        {
            if (!HasNext)
            {
                throw new Exception("No cards left in deck");
            }

            if (rank != null)
            {
                return cards.First(x => x.Rank == rank);
            }

            return cards.Pop();
        }

        /// <summary>
        /// Intialize the deck with a set of cards, in clean order.
        /// </summary>
        public void Initialize()
        {
            cards = new Stack<Card>(GenerateCleanCardSet());
        }

        /// <summary>
        /// Shuffle the cards randomly in compliance with the Fisher-Yates shuffling algorithm
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();

            IList<Card> cardsList = cards.ToList();

            for (int n = cards.Count() - 1; n > 0; n--)
            {
                int k = random.Next(n + 1);
                Card temp = cardsList[n];

                cardsList[n] = cardsList[k];
                cardsList[k] = temp;
            }

            cards = new Stack<Card>(cardsList);
        }

        /// <summary>
        /// Generate a collection of 52 playing cards in factory order.
        /// </summary>
        /// <returns>A collection of 52 playing card in factory order</returns>
        private IEnumerable<Card> GenerateCleanCardSet()
        {
            IList<Card> cards = new List<Card>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < InitialCount / 4; j++)
                {
                    Card card = new Card((Rank)j + 1, (Suit)i);
                    card.ImageUri = CardImageUriFactory?.Invoke(card);
                    cards.Add(card);
                }
            }

            return cards;
        }
    }
}
