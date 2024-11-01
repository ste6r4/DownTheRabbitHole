using TextFilter.Shared;

namespace TextFilter.Services.Interfaces;

public interface IFilterService
{
    public List<string> ApplyFilters(IWordFilter filter, string fileContent);

    public string RemoveWordsFromFileContent(List<string> wordsToRemove, string fileContent);

}