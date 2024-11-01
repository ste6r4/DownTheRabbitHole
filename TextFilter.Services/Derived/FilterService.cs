using TextFilter.Services.Interfaces;
using TextFilter.Shared;
using static System.Text.RegularExpressions.Regex;

namespace TextFilter.Services.Derived;

public class FilterService : IFilterService
{
    public IEnumerable<IWordFilter> Filters { get; set; } = [];

    public FilterService() { }

    public FilterService(IEnumerable<IWordFilter> filters)
    {
        Filters = filters;
    }

    public string ApplyFilters(string fileContent)
    {
        var filteredWords = new List<string>();
        foreach (var filter in Filters)
        {
            var words = Matches(fileContent, AppConstants.RegexPatterns.CompleteWords).Select(m => m.Value).ToList();
            filteredWords.AddRange(filter.Apply(words));
        }
        return RemoveWordsFromFileContent(filteredWords, fileContent);
    }

    public List<string> ApplyFilters(IWordFilter filter, string fileContent)
    {
        var matches = Matches(fileContent, AppConstants.RegexPatterns.CompleteWords);
        var words = matches.Select(m => m.Value).ToList();
        return filter.Apply(words);
    }

    public string RemoveWordsFromFileContent(List<string> wordsToRemove, string fileContent)
    {
        foreach (var word in wordsToRemove)
        {
            var pattern = $@"\b{Escape(word)}\b";
            fileContent = Replace(fileContent, pattern, string.Empty);
        }
        return fileContent;
    }
}