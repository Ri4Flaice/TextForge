using TextForge.Business;
using TextForge.Business.Common;

namespace TextForge.Tests.Business;

/// <summary>
/// Parse files tests.
/// </summary>
public class ParseFilesTests
{
    private ParseFiles _parseFiles;
    private string _pathDirectory;
    private string _finalResultPath;

    /// <summary>
    /// Test settings.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _pathDirectory = GetDirectoryExpressions.GetDirectoryPath();
        _finalResultPath = GetDirectoryExpressions.GetFinalResultTxtPath();

        var files = GetFiles.GetAllFilesInDirectory(_pathDirectory);
        _parseFiles = new ParseFiles(files);

        if (File.Exists(_finalResultPath))
        {
            File.WriteAllText(_finalResultPath, string.Empty);
        }
    }

    /// <summary>
    /// Parse all files test.
    /// </summary>
    [Test]
    public void ParseFilesTest()
    {
        // Arrange
        _parseFiles.ParseAllFiles();

        // Act
        var finalResultContent = File.ReadAllText(_finalResultPath);

        // Assert
        Assert.That(finalResultContent, Is.Not.Empty);
    }
}