using System.Reflection;

namespace TextForge.Business;

/// <summary>
/// Get directory for tests.
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
}