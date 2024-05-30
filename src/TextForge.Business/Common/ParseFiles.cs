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
    /// Parse all files in list.
    /// </summary>
    public void ParseAllFiles()
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
}