namespace TextForge.Business.Common;

/// <summary>
/// Get all files with .srt.
/// </summary>
public static class GetFiles
{
    /// <summary>
    /// Get all files with .srt.
    /// </summary>
    /// <param name="pathDirectory">Path directory.</param>
    /// <returns>A list of the paths.</returns>
    public static List<string> GetAllFilesInDirectory(string pathDirectory)
    {
        try
        {
            var files = Directory.GetFiles(pathDirectory, "*.srt", SearchOption.AllDirectories).ToList();
            return files;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}