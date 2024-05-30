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
            string content;
            string parsedContent;

            foreach (var file in _files)
            {
                content = File.ReadAllText(file);
                parsedContent = ParseContentFile.ParseContent(content);
                File.AppendAllText(finalResult, parsedContent);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}