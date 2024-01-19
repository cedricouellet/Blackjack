namespace CAO.Blackjack.Forms.Models
{
    /// <summary>
    /// A background image in the game.
    /// </summary>
    public class BackgroundImage
    {
        /// <summary>
        /// Gets the unique identifier of the image.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the display name of the image
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the price of the image.
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// Gets or sets whether the image is locked or not.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets the recommended fore color of text when this background image is used.
        /// </summary>
        public Color RecommendedForeColor { get; private set; }

        /// <summary>
        /// Instantiate a background image.
        /// </summary>
        /// <param name="id">The unique identifier of the image.</param>
        /// <param name="name">The display name of the image.</param>
        /// <param name="price">The price of the image.</param>
        /// <param name="recommendedForeColor">The recommended fore color of text when this background image is used.</param>
        public BackgroundImage(string id, string name, int price, Color recommendedForeColor)
        {
            Id = id;
            Name = name;
            Price = price;
            IsLocked = price > 0;
            RecommendedForeColor = recommendedForeColor;
        }

        /// <summary>
        /// Gets the string representation of the background image
        /// </summary>
        /// <returns>The string representation of the background image.</returns>
        public override string ToString()
        {
            if (IsLocked)
            {
                return $"{Name} - {Price:C0}";
            }
            else
            {
                return Name;
            }
        }
    }
}
