namespace TextFilter
{
    public static class FileHelper
    {
        public static string GetFileContent()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var solutionDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;
            var filePath = Path.Combine(solutionDirectory, AppConstants.TextInputFileName);
            var fileContent = File.ReadAllText(filePath);
            return fileContent;
        }
    }
}
