/// <summary>
/// Represents a single song associated with a file, along with some metadata
/// </summary>
public partial class Song
{
    public Song(string filePath, string name, string artists, string album)
    {
        FilePath = filePath;
        Name = name;
        Artists = artists;
        Album = album;
    }

    public Song() { }

    /// <summary>
    /// The file path to the song
    /// </summary>
    public string FilePath = "";

    /// <summary>
    /// The name of the song
    /// </summary>
    public string Name = "";

    /// <summary>
    /// The artists that made the song
    /// </summary>
    public string Artists = "";

    /// <summary>
    /// The album the song belongs to
    /// </summary>
    public string Album = "";

}