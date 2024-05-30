using System.Reflection;

namespace TextForge.Business;

/// <summary>
/// Get directory(file) for tests.
/// </summary>
public static class GetDirectoryExpressions
{
    /// <summary>
    /// Get directory path for tests.
    /// </summary>
    /// <returns>Directory path.</returns>
    /// <param name="resourcesDirectory">Name resources directory. It needs for negative test.</param>
    public static string GetDirectoryPath(string? resourcesDirectory = null)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var outputPath = Path.GetDirectoryName(assembly.Location);

        if (outputPath == null)
        {
            return string.Empty;
        }

        var directoryPath = Path.Combine(outputPath, resourcesDirectory ?? "Resources");

        return directoryPath;
    }

    /// <summary>
    /// Get file path for tests.
    /// </summary>
    /// <returns>File path.</returns>
    public static string GetFinalResultTxtPath()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var outputPath = Path.GetDirectoryName(assembly.Location);

        if (outputPath == null)
        {
            return string.Empty;
        }

        var finalResultPath = Path.Combine(outputPath, "finalResult.txt");

        if (!File.Exists(finalResultPath))
        {
            File.Create(finalResultPath).Dispose();
        }

        return finalResultPath;
    }
}