using System.Diagnostics;
using CAO.Blackjack.Core.Data;

namespace CAO.Blackjack.Core.Models
{
    /// <summary>
    /// A game achievement.
    /// </summary>
    public class Achievement
    {
        /// <summary>
        /// Gets the ID of the achievement.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the achievement.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the achievement.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the function that obtains whether or not the achievement is unlocked.
        /// </summary>
        private readonly Func<GameState, bool> _getCondition;

        /// <summary>
        /// Gets whether or not the achievement is unlocked.
        /// </summary>
        /// <param name="state">The game state used to determine whether or not the achievement is unlocked.</param>
        /// <returns>True if the achievement is unlocked, otherwise false.</returns>
        public bool IsUnlocked(GameState state) => DoesSatisfyCondition(state) || state.UnlockedAchievementIds.Any(x => x == Id);

        /// <summary>
        /// Gets whether or not the game state satisfies the condition for unlocked the achievement.
        /// </summary>
        /// <param name="state">The game state used to determine whether or not the achievement condition is satisfied.</param>
        /// <returns>True if the game state satisfies the condition of the achievement, otherwise false.</returns>
        public bool DoesSatisfyCondition(GameState state) => _getCondition(state);

        /// <summary>
        /// Instantiate an achievement.
        /// </summary>
        /// <param name="id">The ID of the achievement.</param>
        /// <param name="name">The name of the achievement.</param>
        /// <param name="description">The description of the achievement.</param>
        /// <param name="getCondition">The function that obtains whether or not the achievement is unlocked.</param>
        public Achievement(string id, string name, string description, Func<GameState, bool> getCondition)
        {
            Id = id;
            Name = name;
            Description = description;
            _getCondition = getCondition;
        }

        /// <summary>
        /// Gets the string representation of the achievement.
        /// </summary>
        /// <returns>The string representation of the achievement.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
