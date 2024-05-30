﻿using System.Text.RegularExpressions;
using TextForge.Core;

namespace TextForge.Business.Common;

/// <summary>
/// Parse content file.
/// </summary>
public static class ParseContentFile
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
            content = Regex.Replace(content, @"^\d+\s+", string.Empty, RegexOptions.Multiline);
            content = Regex.Replace(content, @"[\d:,->]+\s*-->\s*[\d:,->]+\s*", string.Empty);
            content = content.Replace("\r\n", " ");
            content = Regex.Replace(content, @"\s+", " ").Trim();
        }
        catch (Exception e)
        {
            var logs = new Logs(e, nameof(Errors.TF0500), Errors.TF0500);
            logs.WriteErrorInLogs();
            throw;
        }

        return content;
    }
}