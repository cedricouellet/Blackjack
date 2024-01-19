using CAO.Blackjack.Core.Data;
using System.Text.Json;

namespace CAO.Blackjack.Forms.Utils
{
    /// <summary>
    /// Utility methods for operating on the application's save file
    /// </summary>
    public static class AppSaveFileUtils
    {
        /// <summary>
        /// Gets whether or not the save file exists
        /// </summary>
        public static bool SaveFileExists => File.Exists(SaveFilePath);

        /// <summary>
        /// The name of the save file
        /// </summary>
        private static readonly string SaveFileName = "save.json";

        /// <summary>
        /// Gets the path to the Windows OS AppData folder
        /// </summary>
        private static string WindowsAppDataFolderPath => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        /// <summary>
        /// Gets the path to the game data folder 
        /// </summary>
        private static string GameDataFolderPath => Path.Combine(WindowsAppDataFolderPath, Application.CompanyName, Application.ProductName);

        /// <summary>
        /// Gets the path to the save file
        /// </summary>
        private static string SaveFilePath => Path.Combine(GameDataFolderPath, SaveFileName);

        /// <summary>
        /// Delete the game's save file
        /// </summary>
        public static void DeleteSaveFile()
        {
            if (!SaveFileExists)
            {
                return;
            }

            try
            {
                File.Delete(SaveFilePath);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Saves the game state data to a file, overriding its previous data.
        /// </summary>
        /// <param name="data">The game state data to save to a file.</param>
        /// <returns>True if the game state data was successfully saved to a file, otherwise false.</returns>
        public static bool SaveGame(GameState data)
        {
            try
            {
                EnsureGameFolderCreated();

                if (SaveFileExists)
                {
                    File.Delete(SaveFilePath);
                }

                File.Create(SaveFilePath).Close();

                string jsonContent = JsonSerializer.Serialize(data);
                File.WriteAllText(SaveFilePath, jsonContent);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the game state data from a file.
        /// </summary>
        /// <param name="data">The game state data that was found if successful, otherwise null.</param>
        /// <returns>True if the game state data was successfully loaded from a file, otherwise false.</returns>
        public static bool LoadGame(out GameState? data)
        {
            data = null;

            if (!SaveFileExists)
            {
                return false;
            }

            try
            {
                string jsonContent = File.ReadAllText(SaveFilePath);
                data = JsonSerializer.Deserialize<GameState>(jsonContent);

                return data != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Ensures that the game folder is created. 
        /// <para>
        /// If it does not exist, it will create it.
        /// </para>
        /// </summary>
        private static void EnsureGameFolderCreated()
        {
            if (Directory.Exists(GameDataFolderPath))
            {
                return;
            }

            try
            {
                Directory.CreateDirectory(GameDataFolderPath);
            }
            catch
            {
                throw;
            }
        }
    }
}
