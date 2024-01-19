using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using CAO.Blackjack.Core.Enum;
using CAO.Blackjack.Core.Models;

namespace CAO.Blackjack.Core.Data
{
    /// <summary>
    /// Represents the Blackjack game's serializable state data.
    /// </summary>
    [Serializable]
    public class GameState : INotifyPropertyChanged
    {
        /// <summary>
        /// Raises the event for a property that has changed.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Backing field for Deck property
        /// </summary>
        private CardDeck? deck;

        /// <summary>
        /// Backing field for the CurrentTurn property
        /// </summary>
        private PlayerType? _currentTurn;

        /// <summary>
        /// Backing field for the InProgress property
        /// </summary>
        private bool _inProgress;

        /// <summary>
        /// Backing field for the BankAmount property
        /// </summary>
        private int _bankAmount;

        /// <summary>
        /// Backing field for the BetAmount property
        /// </summary>
        private int _betAmount;

        /// <summary>
        /// Backing field for the WinCount property
        /// </summary>
        private int _winCount;

        /// <summary>
        /// Backing field for the LossCount property
        /// </summary>
        private int _lossCount;

        /// <summary>
        /// Backing field for the TieCount property.
        /// </summary>
        private int _tieCount;

        /// <summary>
        /// Backing field for the GameVersion property.
        /// </summary>
        private string? _gameVersion;

        /// <summary>
        /// Backing field for the PlayerHand property.
        /// </summary>
        private Hand? _playerHand;

        /// <summary>
        /// Backing field for the DealerHand property.
        /// </summary>
        private Hand? _dealerHand;

        /// <summary>
        /// Backing field for the PlayerDoubled property.
        /// </summary>
        private bool _didPlayerDouble;

        /// <summary>
        /// Backing field for the PurchasedBackgroundIds property.
        /// </summary>
        private string[]? _purchasedBackgroundsIds;

        /// <summary>
        /// Backing field for the UnlockedAchievementIds property.
        /// </summary>
        private string[]? _unlockedAchievementIds;

        /// <summary>
        /// Backing field for the ActiveBackgroundId property.
        /// </summary>
        private string? _activeBackgroundId;

        /// <summary>
        /// Gets or sets the deck of the game
        /// <para>
        /// - Not serialized
        /// </para>
        /// </summary>
        [JsonIgnore]
        public CardDeck? Deck
        {
            get => deck;
            set
            {
                if (value == deck) return;
                deck = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the player type associated to the game's current turn 
        /// <para>
        /// - A null value means that there is no current turn
        /// </para>
        /// <para>
        /// - Not serialized
        /// </para>
        /// </summary>
        [JsonIgnore]
        public PlayerType? CurrentTurn
        {
            get => _currentTurn;
            set
            {
                if (value == _currentTurn) return;
                _currentTurn = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether or not the game is currently in progress
        /// <para>
        /// - Not serialized
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool InProgress
        {
            get => _inProgress;
            set
            {
                if (value == _inProgress) return;
                _inProgress = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the game's current bet amount
        /// <para>
        /// - Not serialized
        /// </para>
        /// </summary>
        [JsonIgnore]
        public int BetAmount
        {
            get => _betAmount;
            set
            {
                if (value == _betAmount) return;
                _betAmount = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets the player's hand 
        /// <para>
        /// - Not serialized
        /// </para>
        /// </summary>
        [JsonIgnore]
        public Hand? PlayerHand
        {
            get => _playerHand;
            set
            {
                if (value == _playerHand) return;
                _playerHand = value;

                if (_playerHand != null)
                {
                    _playerHand.PropertyChanged += PlayerHand_PropertyChanged;
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the dealer's hand
        /// <para>
        /// - Not serialized
        /// </para>
        /// </summary>
        [JsonIgnore]
        public Hand? DealerHand
        {
            get => _dealerHand;
            set
            {
                if (value == _dealerHand) return;
                _dealerHand = value;

                if (_dealerHand != null)
                {
                    _dealerHand.PropertyChanged += DealerHand_PropertyChanged;
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether or not the player double their bet.
        /// <para>
        /// - Not serialized
        /// </para>
        /// </summary>
        [JsonIgnore]
        public bool DidPlayerDouble
        {
            get => _didPlayerDouble;
            set
            {
                if (value == _didPlayerDouble) return;

                _didPlayerDouble = value;

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the game's current bank amount
        /// </summary>
        public int BankAmount
        {
            get => _bankAmount;
            set
            {
                if (value == _bankAmount) return;
                _bankAmount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the game's number of wins
        /// </summary>
        public int WinCount
        {
            get => _winCount;
            set
            {
                if (value == _winCount) return;
                _winCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the game's number of losses
        /// </summary>
        public int LossCount
        {
            get => _lossCount;
            set
            {
                if (value == _lossCount) return;
                _lossCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the game's number of ties 
        /// </summary>
        public int TieCount
        {
            get => _tieCount;
            set
            {
                if (value == _tieCount) return;
                _tieCount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the game's version
        /// </summary>
        public string? GameVersion
        {
            get => _gameVersion;
            set
            {
                if (value == _gameVersion) return;
                _gameVersion = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Gets or sets the purchased background IDs.
        /// </summary>
        public IEnumerable<string> PurchasedBackgroundIds
        {
            get
            {
                _purchasedBackgroundsIds ??= Array.Empty<string>();

                return _purchasedBackgroundsIds;
            }
            set
            {
                if (_purchasedBackgroundsIds == value) return;
                _purchasedBackgroundsIds = value.ToArray();

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the active background ID.
        /// </summary>
        public string? ActiveBackgroundId
        {
            get => _activeBackgroundId;
            set
            {
                if (value == _activeBackgroundId) return;
                _activeBackgroundId = value;

                OnPropertyChanged();

                if (_activeBackgroundId != null)
                {
                    AddPurchasedBackground(_activeBackgroundId);
                }
            }
        }

        /// <summary>
        /// Gets or sets the unlocked achievement IDs.
        /// </summary>
        public IEnumerable<string> UnlockedAchievementIds
        {
            get
            {
                _unlockedAchievementIds ??= Array.Empty<string>();

                return _unlockedAchievementIds;
            }
            set
            {
                if (_unlockedAchievementIds == value) return;
                _unlockedAchievementIds = value.ToArray();

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Add a purchased background.
        /// </summary>
        /// <param name="backgroundId">The ID of the background to add to the purchased backgrounds.</param>
        public void AddPurchasedBackground(string backgroundId)
        {
            if (PurchasedBackgroundIds.Contains(backgroundId))
            {
                return;
            }

            PurchasedBackgroundIds = PurchasedBackgroundIds.Append(backgroundId);
        }

        /// <summary>
        /// Add an unlocked achievement.
        /// </summary>
        /// <param name="achievementId">The ID of the achievement to add to the unlocked achievements.</param>
        public void AddAchievement(string achievementId)
        {
            if (UnlockedAchievementIds.Contains(achievementId))
            {
                return;
            }

            UnlockedAchievementIds = UnlockedAchievementIds.Append(achievementId);
        }

        /// <summary>
        /// Handles a property change in the internal player hand. 
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The arguments of the event that was raised.</param>
        private void PlayerHand_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(PlayerHand));
        }

        /// <summary>
        /// Handles a property change in the internal dealer hand. 
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The arguments of the event that was raised.</param>
        private void DealerHand_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DealerHand));
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
