namespace TextFilter.Services.Helpers
{
    public static class FileHelper
    {
        public static string GetFileContent(string currentDirectory, string fileName)
        {
            var solutionDirectory = Directory.GetParent(currentDirectory)?.Parent?.Parent?.Parent?.FullName;
            var filePath = Path.Combine(solutionDirectory!, fileName);
            var fileContent = File.ReadAllText(filePath);
            return fileContent;
        }
    }
}
