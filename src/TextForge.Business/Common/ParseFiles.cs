using System.Text;

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

            var allContents = new StringBuilder();

            foreach (var file in files)
            {
                allContents.AppendLine(File.ReadAllText(file));
            }

            var parsedContent = ParseContentFile.ParseContent(allContents.ToString());
            File.WriteAllText(finalResult, parsedContent);
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
            var allContents = new StringBuilder();

            foreach (var file in files)
            {
                allContents.AppendLine(File.ReadAllText(file));
            }

            var parsedContent = ParseContentFile.ParseContent(allContents.ToString());
            File.WriteAllText(Path.Combine(finalFilePath, "result.txt"), parsedContent);
        }
        catch (Exception e)
        {
            var logs = new Logs(e, nameof(Errors.TF0500), Errors.TF0500);
            logs.WriteErrorInLogs();
            throw;
        }
    }
}