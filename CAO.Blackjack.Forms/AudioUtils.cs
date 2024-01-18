using System.Media;

namespace CAO.Blackjack.Forms
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
        /// <param name="audioResource">The audio resource stream to play</param>
        public static void Play(Stream audioResource)
        {
            _player.Stream = audioResource;
            _player.Play();
        }
    }
}
