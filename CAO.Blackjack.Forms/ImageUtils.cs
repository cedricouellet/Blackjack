using CAO.Blackjack.Core;
using CAO.Blackjack.Forms.Properties;

namespace CAO.Blackjack.Forms
{
    /// <summary>
    /// Utility methods for operating on image resources
    /// </summary>
    public static class ImageUtils
    {
        /// <summary>
        /// The default background ID.
        /// </summary>
        public const string DefaultBackgroundId = "bg_default";

        /// <summary>
        /// Cached image dictionary
        /// </summary>
        private static readonly Dictionary<string, Bitmap> _bipmapDict = new Dictionary<string, Bitmap>() 
        {
            { "card_0_1", Resources.card_0_1 },
            { "card_0_2", Resources.card_0_2 },
            { "card_0_3", Resources.card_0_3 },
            { "card_0_4", Resources.card_0_4 },
            { "card_0_5", Resources.card_0_5 },
            { "card_0_6", Resources.card_0_6 },
            { "card_0_7", Resources.card_0_7 },
            { "card_0_8", Resources.card_0_8 },
            { "card_0_9", Resources.card_0_9 },
            { "card_0_10", Resources.card_0_10 },
            { "card_0_11", Resources.card_0_11 },
            { "card_0_12", Resources.card_0_12 },
            { "card_0_13", Resources.card_0_13 },
            { "card_1_1", Resources.card_1_1 },
            { "card_1_2", Resources.card_1_2 },
            { "card_1_3", Resources.card_1_3 },
            { "card_1_4", Resources.card_1_4 },
            { "card_1_5", Resources.card_1_5 },
            { "card_1_6", Resources.card_1_6 },
            { "card_1_7", Resources.card_1_7 },
            { "card_1_8", Resources.card_1_8 },
            { "card_1_9", Resources.card_1_9 },
            { "card_1_10", Resources.card_1_10 },
            { "card_1_11", Resources.card_1_11 },
            { "card_1_12", Resources.card_1_12 },
            { "card_1_13", Resources.card_1_13 },
            { "card_2_1", Resources.card_2_1 },
            { "card_2_2", Resources.card_2_2 },
            { "card_2_3", Resources.card_2_3 },
            { "card_2_4", Resources.card_2_4 },
            { "card_2_5", Resources.card_2_5 },
            { "card_2_6", Resources.card_2_6 },
            { "card_2_7", Resources.card_2_7 },
            { "card_2_8", Resources.card_2_8 },
            { "card_2_9", Resources.card_2_9 },
            { "card_2_10", Resources.card_2_10 },
            { "card_2_11", Resources.card_2_11 },
            { "card_2_12", Resources.card_2_12 },
            { "card_2_13", Resources.card_2_13 },
            { "card_3_1", Resources.card_3_1 },
            { "card_3_2", Resources.card_3_2 },
            { "card_3_3", Resources.card_3_3 },
            { "card_3_4", Resources.card_3_4 },
            { "card_3_5", Resources.card_3_5 },
            { "card_3_6", Resources.card_3_6 },
            { "card_3_7", Resources.card_3_7 },
            { "card_3_8", Resources.card_3_8 },
            { "card_3_9", Resources.card_3_9 },
            { "card_3_10", Resources.card_3_10 },
            { "card_3_11", Resources.card_3_11 },
            { "card_3_12", Resources.card_3_12 },
            { "card_3_13", Resources.card_3_13 },
            { "card_back", Resources.card_back },
            { "bg_zoo", Resources.bg_zoo },
            { "bg_default", Resources.bg_default },
            { "bg_learning_center", Resources.bg_learning_center },
            { "bg_animal_pig", Resources.bg_animal_pig },
            { "bg_hacker", Resources.bg_hacker },
            { "bg_gentlemanly", Resources.bg_gentlemanly },
            { "bg_office", Resources.bg_office },
            { "bg_living_room", Resources.bg_living_room },
            { "bg_casino", Resources.bg_casino },
        };

        /// <summary>
        /// The available backgrounds
        /// </summary>
        public static IEnumerable<BackgroundImage> Backgrounds = new List<BackgroundImage>
        {
            new("bg_default", "Default", 0, isLocked: false),
            new("bg_office", "Office", 2500, isLocked: true),
            new("bg_learning_center", "Learning Center", 5000, isLocked: true),
            new("bg_gentlemanly", "Gentlemanly", 7500, isLocked: true),
            new("bg_animal_pig", "Animal Pig", 10000, isLocked: true),
            new("bg_living_room", "Living Room", 12500, isLocked: true),
            new("bg_hacker", "Hacker", 15000, isLocked: true),
            new("bg_zoo", "Zoo", 17500, isLocked: true),
        };

        /// <summary>
        /// Gets the bitmap associated to a resource.
        /// </summary>
        /// <param name="resourceKey">The key of the resource for which to get the bitmap</param>
        /// <returns>The bitmap associated to the resource if found, otherwise null</returns>
        public static Bitmap? GetBitmapResource(string resourceKey)
        {
            if (!_bipmapDict.ContainsKey(resourceKey))
            {
                return null;
            }

            return _bipmapDict[resourceKey];
        }
    }
}
