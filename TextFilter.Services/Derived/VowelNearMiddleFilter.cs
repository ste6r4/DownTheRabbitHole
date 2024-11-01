using TextFilter.Services.Interfaces;
using TextFilter.Shared;
using static System.Text.RegularExpressions.Regex;

namespace TextFilter.Services.Derived;

public class VowelNearMiddleFilter : IWordFilter
{
    public List<string> Apply(List<string> words)
    {
        return words.Where(IsVowelNearTheMiddle).ToList();
    }

    public static bool IsNumberOddOrEven(int length)
    {
        return length % 2 == 1;
    }

    public static bool IsVowelNearTheMiddle(string word)
    {
        var length = word.Length;
        var middleIndex = length / 2;
        if (IsNumberOddOrEven(length))
        {
            var middleCharacter = word[middleIndex];
            return IsMatch(middleCharacter.ToString(), AppConstants.RegexPatterns.VowelMatches);
        }
        var middleChars = word.Substring(middleIndex - 1, 2);
        return IsMatch(middleChars, AppConstants.RegexPatterns.VowelMatches);
    }

  
}