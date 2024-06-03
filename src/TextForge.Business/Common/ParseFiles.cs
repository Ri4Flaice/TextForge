using TextForge.Core;

namespace TextForge.Business.Common;

/// <summary>
/// Parse files in directory.
/// </summary>
public static class ParseFiles
{
    /// <summary>
    /// Parse all files in list for tests.
    /// </summary>
    /// <param name="files">List of files.</param>
    public static void ParseAllFilesForTests(List<string> files)
    {
        try
        {
            var finalResult = GetDirectoryExpressions.GetFinalResultTxtPath();

            foreach (var parsedContent in files.Select(File.ReadAllText).Select(ParseContentFile.ParseContent))
            {
                File.AppendAllText(finalResult, parsedContent);
            }
        }
        catch (Exception e)
        {
            var logs = new Logs(e, nameof(Errors.TF0500), Errors.TF0500);
            logs.WriteErrorInLogs();
            throw;
        }
    }

    /// <summary>
    /// Parse all files in list.
    /// </summary>
    /// <param name="files">List of files.</param>
    /// <param name="finalFilePath">File path, where saved final file.</param>
    public static void ParseAllFiles(List<string> files, string finalFilePath)
    {
        try
        {
            foreach (var parsedContent in files.Select(File.ReadAllText).Select(ParseContentFile.ParseContent))
            {
                File.WriteAllText(Path.Combine(finalFilePath, "result.txt"), parsedContent);
            }
        }
        catch (Exception e)
        {
            var logs = new Logs(e, nameof(Errors.TF0500), Errors.TF0500);
            logs.WriteErrorInLogs();
            throw;
        }
    }
}