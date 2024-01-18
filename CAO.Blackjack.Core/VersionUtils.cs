namespace CAO.Blackjack.Core
{
    /// <summary>
    /// Utility methods for operating on application versioning
    /// </summary>
    public static class VersionUtils
    {
        /// <summary>
        /// Determine whether or not a version is compatible with the application's current version
        /// </summary>
        /// <param name="version">The version to check for compatibility with the application's current version</param>
        /// <returns>True if the version is compatible with the application's current version, otherwise false</returns>
        public static bool DetermineVersionIsCompatible(string? version, string? otherVersion)
        {
            return GetMajorVersion(version) == GetMajorVersion(otherVersion);
        }

        /// <summary>
        /// Get the major version from a version string.
        /// </summary>
        /// <param name="version">The version string from which to retrieve the major version.</param>
        /// <returns>The major version if found, otherwise null.</returns>
        private static int? GetMajorVersion(string? version)
        {
            return version?.Split(".").Select(x => int.Parse(x)).FirstOrDefault();
        }
    }
}
