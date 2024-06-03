using TextForge.Core;

namespace TextForge.Business.Common;

/// <summary>
/// Parse files in directory.
/// </summary>
public class ParseFiles
{
    private readonly List<string> _files;

    /// <summary>
    /// Initializes a new instance of the class <see cref="ParseFiles"/>.
    /// </summary>
    /// <param name="files">List files.</param>
    public ParseFiles(List<string> files)
    {
        _files = files;
    }

    /// <summary>
    /// Parse all files in list for tests.
    /// </summary>
    public void ParseAllFilesForTests()
    {
        try
        {
            var finalResult = GetDirectoryExpressions.GetFinalResultTxtPath();

            foreach (var parsedContent in _files.Select(File.ReadAllText).Select(ParseContentFile.ParseContent))
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
    /// <param name="finalFilePath">File path, where saved final file.</param>
    public void ParseAllFiles(string finalFilePath)
    {
        try
        {
            foreach (var parsedContent in _files.Select(File.ReadAllText).Select(ParseContentFile.ParseContent))
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