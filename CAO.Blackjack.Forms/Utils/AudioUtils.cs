using CAO.Blackjack.Forms.Properties;
using System.Media;

namespace CAO.Blackjack.Forms.Utils
{
    /// <summary>
    /// Utility methods for operating on audio resources
    /// </summary>
    public static class AudioUtils
    {
        /// <summary>
        /// The internal sound player used to play audio clips
        /// </summary>
        private static readonly SoundPlayer _player = new SoundPlayer();

        /// <summary>
        /// Play a sound from an audio resource
        /// </summary>
        /// <param name="resourceKey">The resource key of the audio stream to play</param>
        public static void Play(string resourceKey)
        {
            UnmanagedMemoryStream? stream = Resources.ResourceManager.GetStream(resourceKey);
            if (stream == null)
            {
                return;
            }

            using (stream)
            {
                _player.Stream = stream;
                _player.Play();
            }

            _player.Stream = null;
        }

        /// <summary>
        /// Contains all available application audio clip names.
        /// </summary>
        public static class Sounds
        {
            /// <summary>
            /// The bet sound effect name.
            /// </summary>
            public static readonly string SfxBet = "sfx_bet";

            /// <summary>
            /// The button click sound effect name.
            /// </summary>
            public static readonly string SfxButtonClick = "sfx_button_click";

            /// <summary>
            /// The card sound effect name.
            /// </summary>
            public static readonly string SfxCard = "sfx_card";

            /// <summary>
            /// The exit sound effect name.
            /// </summary>
            public static readonly string SfxExit = "sfx_exit";

            /// <summary>
            /// The lose sound effect name.
            /// </summary>
            public static readonly string SfxLose = "sfx_lose";

            /// <summary>
            /// The tie sound effect name.
            /// </summary>
            public static readonly string SfxTie = "sfx_tie";

            /// <summary>
            /// The win sound effect name.
            /// </summary>
            public static readonly string SfxWin = "sfx_win";

            /// <summary>
            /// The shuffle sound effect name.
            /// </summary>
            public static readonly string SfxShuffle = "sfx_shuffle";
        }
    }


}
