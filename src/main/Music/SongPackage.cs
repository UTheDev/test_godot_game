﻿//using System;
using System.IO;

namespace Jumpvalley.Music
{
    /// <summary>
    /// Represents a folder (such as one on the filesystem) that contains a song and its attribution metadata.
    /// </summary>
    public class SongPackage
    {
        /// <summary>
        /// Data as raw text that comes from "attribution.txt" within the folder
        /// </summary>
        public string AttributionData = "";

        /// <summary>
        /// The data of the corresponding "attribution.txt" file
        /// </summary>
        public AttributionFile AttributionFile = null;

        /// <summary>
        /// The name of the song's audio file
        /// </summary>
        public string SongFileName;

        /// <summary>
        /// The directory path of this <see cref="SongPackage"/> with trailing slashes and trailing backslashes removed
        /// </summary>
        public string Path = "";

        /// <summary>
        /// Creates a SongPackage instance for a given folder path
        /// </summary>
        /// <param name="path">The folder path</param>
        public SongPackage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                // Some like to end the paths with an extra "/" or "\". Account for this.
                if (path.EndsWith("/") || path.EndsWith("\\"))
                {
                    path = path.Substring(0, path.Length - 1);
                }

                Path = path;

                // Add the removed slash back for convenience in the next bit of code
                path += "/";

                // Try to read the contents of the attribution file in the package.
                StreamReader attributionStreamReader = null;
                try
                {
                    using (attributionStreamReader = new StreamReader(path + "attribution.txt"))
                    {
                        AttributionData = attributionStreamReader.ReadToEnd();
                        AttributionFile = new AttributionFile(AttributionData);
                    }
                }
                catch (System.Exception e)
                {
                    // Attribution files can be excluded from a song package although it's recommended that the user put one anyway.
                    if (e is FileNotFoundException)
                    {
                        if (attributionStreamReader != null)
                        {
                            attributionStreamReader.Dispose();
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}