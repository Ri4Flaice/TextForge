using TextForge.Core;

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

            if (files.Count == 0)
            {
                var logs = new Logs(nameof(Errors.TF0404), Errors.TF0404);
                logs.WriteErrorInLogs();
            }

            return files;
        }
        catch (Exception e)
        {
            var logs = new Logs(e, nameof(Errors.TF0500), Errors.TF0500);
            logs.WriteErrorInLogs();
            throw;
        }
    }
}