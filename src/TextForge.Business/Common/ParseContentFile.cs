using System.Text.RegularExpressions;

using TextForge.Core;

namespace TextForge.Business.Common;

/// <summary>
/// Parse content file.
/// </summary>
public static partial class ParseContentFile
{
    /// <summary>
    /// Parse content file.
    /// </summary>
    /// <param name="content">File content.</param>
    /// <returns>Formatted file contents.</returns>
    public static string ParseContent(string content)
    {
        try
        {
            content = DeleteNumbering().Replace(content, string.Empty);
            content = DeleteTiming().Replace(content, string.Empty);
            content = content.Replace("\r\n", " ");
            content = DeleteUnnecessarySpaces().Replace(content, " ").Trim();
        }
        catch (Exception e)
        {
            var logs = new Logs(e, nameof(Errors.TF0500), Errors.TF0500);
            logs.WriteErrorInLogs();
            throw;
        }

        return content;
    }

    /// <summary>
    /// Deleting all numbering in lines.
    /// </summary>
    [GeneratedRegex(@"^\d+\s+", RegexOptions.Multiline)]
    private static partial Regex DeleteNumbering();

    /// <summary>
    /// Deleting all timings in rows.
    /// </summary>
    [GeneratedRegex(@"[\d:,->]+\s*-->\s*[\d:,->]+\s*")]
    private static partial Regex DeleteTiming();

    /// <summary>
    /// Removing all unnecessary spaces in the lines.
    /// </summary>
    [GeneratedRegex(@"\s+")]
    private static partial Regex DeleteUnnecessarySpaces();
}