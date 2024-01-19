using CAO.Blackjack.Forms.Models;
using CAO.Blackjack.Forms.Properties;

namespace CAO.Blackjack.Forms.Utils
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
        /// Cached image dictionary, helps to reduce memory bloat when accessing images,
        /// </summary>
        private static readonly Dictionary<string, Bitmap> _imageDict = new()
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
            { "bg_classic", Resources.bg_classic },
            { "bg_learning_center", Resources.bg_learning_center },
            { "bg_animal_pig", Resources.bg_animal_pig },
            { "bg_hacker", Resources.bg_hacker },
            { "bg_gentlemanly", Resources.bg_gentlemanly },
            { "bg_office", Resources.bg_office },
            { "bg_living_room", Resources.bg_living_room },
            { "bg_casino", Resources.bg_casino },
            { "bg_wakanda", Resources.bg_wakanda },
            { "bg_cyber_car", Resources.bg_cyber_car },
            { "bg_black_hole", Resources.bg_black_hole },
            { "bg_trudeau", Resources.bg_trudeau },
            { "bg_doomer", Resources.bg_doomer },
            { "bg_space", Resources.bg_space },
        };

        /// <summary>
        /// The available game background images.
        /// </summary>
        public static readonly IEnumerable<BackgroundImage> BackgroundImages = new BackgroundImage[]
        {
            new("bg_default", "Default", 0, Color.White),
            new("bg_classic", "Classic", 100, Color.White),
            new("bg_wakanda", "Wakanda", 250, Color.White),
            new("bg_black_hole", "Black Hole", 500, Color.LightBlue),
            new("bg_cyber_car", "Cyber Car", 750, Color.White),
            new("bg_space", "Space", 1000, Color.LightYellow),
            new("bg_doomer", "Doomer", 1500, Color.White),
            new("bg_office", "Office", 2000, Color.White),
            new("bg_gentlemanly", "Gentlemanly", 2500, Color.White),
            new("bg_living_room", "Living Room", 3000, Color.White),
            new("bg_learning_center", "Learning Center (NSFW)", 3500, Color.White),
            new("bg_trudeau", "Trudeau (Politically NSFW)", 4000, Color.DeepSkyBlue),
            new("bg_animal_pig", "Animal Pig", 5000, Color.White),
            new("bg_hacker", "Hacker (NSFW)", 8000, Color.White),
            new("bg_zoo", "Zoo (NSFW)", 12000, Color.White),
        };

        /// <summary>
        /// Gets the bitmap associated to a resource.
        /// </summary>
        /// <param name="resourceKey">The key of the resource for which to get the bitmap</param>
        /// <returns>The bitmap associated to the resource if found, otherwise null</returns>
        public static Bitmap? GetBitmapResource(string resourceKey)
        {
            if (!_imageDict.ContainsKey(resourceKey))
            {
                return null;
            }

            return _imageDict[resourceKey];
        }
    }
}
