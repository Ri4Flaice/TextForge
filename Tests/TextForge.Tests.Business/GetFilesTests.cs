using TextForge.Business;
using TextForge.Business.Common;

namespace TextForge.Tests.Business;

/// <summary>
/// Get all files with .srt tests.
/// </summary>
[TestFixture]
public class GetFilesTests
{
    /// <summary>
    /// Get all files with .srt tests.
    /// </summary>
    [Test]
    public void GetAllFiles()
    {
        // Arrange
        var pathDirectory = GetDirectoryExpressions.GetDirectoryPath();

        // Act
        var files = GetFiles.GetAllFilesInDirectory(pathDirectory);

        // Assert
        Assert.That(files, Is.Not.Empty);
    }

    /// <summary>
    /// Get all files negative test with non-existent directory.
    /// </summary>
    [Test]
    public void GetAllFilesNonExistentDirectory()
    {
        // Arrange
        var nonExistentDirectory = GetDirectoryExpressions.GetDirectoryPath("Resource");

        // Act && Assert
        Assert.Throws<DirectoryNotFoundException>(() =>
        {
            GetFiles.GetAllFilesInDirectory(nonExistentDirectory);
        });
    }
}