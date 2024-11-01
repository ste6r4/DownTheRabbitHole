namespace TextFilter.Services.Interfaces;

public interface IWordFilter
{
    List<string> Apply(List<string> words);
}