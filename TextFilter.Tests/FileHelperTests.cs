using FluentAssertions;
using TextFilter.Services.Helpers;

namespace TextFilter.Tests
{
    public class FileHelperTests : IDisposable
    {
        private string _filePathToCleanUp = string.Empty;

        [Fact]
        public void GetFileContent_ValidFile_ReturnsCorrectContent()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var fileName = "testfile.txt";
            var expectedContent = "This is a test file content.";
            var solutionDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.Parent?.FullName;
            _filePathToCleanUp = Path.Combine(solutionDirectory!, fileName);
            File.WriteAllText(_filePathToCleanUp, expectedContent);
            
            var result = FileHelper.GetFileContent(currentDirectory, fileName);
            
            result.Should().Be(expectedContent);
        }

        [Fact]
        public void GetFileContent_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var fileName = "nonexistentfile.txt";

            Assert.Throws<FileNotFoundException>(() => FileHelper.GetFileContent(currentDirectory, fileName));
        }

        public void Dispose()
        {
            if (File.Exists(_filePathToCleanUp))
            {
                File.Delete(_filePathToCleanUp);
            }
        }
    }
}
