using System.ComponentModel;
using System.Runtime.CompilerServices;
using CAO.Blackjack.Core.Enum;

namespace CAO.Blackjack.Core.Models
{
    /// <summary>
    /// A Blackjack player's hand
    /// </summary>
    public class Hand : INotifyPropertyChanged
    {
        /// <summary>
        /// Raises the event for a property that has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets the collection of cards in the hand.
        /// </summary>
        public IEnumerable<Card> Cards => _cards;

        /// <summary>
        /// Gets the hand's player type.
        /// </summary>
        public PlayerType PlayerType { get; private set; }

        /// <summary>
        /// Gets whether or not the hand is a soft hand or less.
        /// </summary>
        public bool IsSoftHandOrLess
        {
            get
            {
                return Sum < 17 || Sum == 17 && _cards.Any(x => x.Rank == Rank.Ace);
            }
        }

        /// <summary>
        /// Gets whether or not the sum of the hand is ambiguous.
        /// </summary>
        public bool IsSumAmbiguous
        {
            get
            {
                (int sumA, int sumB) = PossibleSums;
                return sumA != sumB && sumA < 21 && sumB < 21;
            }
        }

        /// <summary>
        /// Gets the sum of the hand.
        /// </summary>
        public int Sum
        {
            get
            {
                int sum = _cards.Sum(x => x.Rank == Rank.Ace ? 11 : x.Value);

                if (sum > 21)
                {
                    int aceCount = _cards.Count(x => x.Rank == Rank.Ace);
                    sum -= aceCount * 10;
                }

                return sum;
            }
        }

        /// <summary>
        /// Gets the two possible sums of the hand.
        /// </summary>
        public (int, int) PossibleSums
        {
            get
            {
                int sumWithAcesAsOne = _cards.Sum(x => x.Rank == Rank.Ace ? 1 : x.Value);
                int sumWithAcesAsEleven = _cards.Sum(x => x.Rank == Rank.Ace ? 11 : x.Value);

                return (sumWithAcesAsOne, sumWithAcesAsEleven);
            }
        }

        /// <summary>
        /// The internal list of cards
        /// </summary>
        public readonly IList<Card> _cards = new List<Card>();

        /// <summary>
        /// Instantiate a new hand.
        /// </summary>
        /// <param name="playerType">The player type of the hand.</param>
        public Hand(PlayerType playerType)
        {
            PlayerType = playerType;
            OnPropertyChanged(nameof(Cards));
            OnPropertyChanged(nameof(PlayerType));
        }

        /// <summary>
        /// Add a card to the hand.
        /// </summary>
        /// <param name="card">The card to add to the hand.</param>
        public void AddCard(Card card)
        {
            _cards.Add(card);
            OnPropertyChanged(nameof(Cards));
        }

        /// <summary>
        /// Gets a card in the hand.
        /// </summary>
        /// <param name="index">The index of the card.</param>
        /// <returns>The card at the specified index if found, otherwise null.</returns>
        public Card? GetCard(int index)
        {
            return _cards.ElementAtOrDefault(index);
        }

        /// <summary>
        /// Raises the PropertyChanged event for the calling member's name.
        /// </summary>
        /// <param name="name">The caller's member name. Will be supplied automatically if not provided.</param>
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
