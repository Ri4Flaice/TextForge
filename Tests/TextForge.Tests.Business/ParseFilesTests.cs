using TextForge.Business;
using TextForge.Business.Common;

namespace TextForge.Tests.Business;

/// <summary>
/// Parse files tests.
/// </summary>
public class ParseFilesTests
{
    private string _pathDirectory;
    private string _finalResultPath;
    private List<string> _files;

    /// <summary>
    /// Test settings.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _pathDirectory = GetDirectoryExpressions.GetDirectoryPath();
        _finalResultPath = GetDirectoryExpressions.GetFinalResultTxtPath();

        _files = GetFiles.GetAllFilesInDirectory(_pathDirectory);

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
        ParseFiles.ParseAllFilesForTests(_files);

        // Act
        var finalResultContent = File.ReadAllText(_finalResultPath);

        // Assert
        Assert.That(finalResultContent, Is.Not.Empty);
    }
}