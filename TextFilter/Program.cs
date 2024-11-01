namespace TextFilter;

internal class Program
{
    static void Main()
    {
        try
        {
            var filter = new Filter();
            var fileContent = FileHelper.GetFileContent();
            var excludedWordsForFilterOne = filter.ApplyFilters(fileContent, FilterType.Filter1);
            var excludedWordsForFilterTwo = filter.ApplyFilters(fileContent, FilterType.Filter2);
            var excludedWordsForFilterThree = filter.ApplyFilters(fileContent, FilterType.Filter3);
            var allExcludedWords = excludedWordsForFilterOne
                .Concat(excludedWordsForFilterTwo)
                .Concat(excludedWordsForFilterThree)
                .ToList();
            var filteredContent = filter.RemoveWordsFromFileContent(allExcludedWords, fileContent);
            Console.WriteLine(filteredContent);
        }
        catch (Exception ex)
        {           
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}