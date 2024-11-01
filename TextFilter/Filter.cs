using static System.Text.RegularExpressions.Regex;

namespace TextFilter
{
    public class Filter
    {
        private const string VowelMatchingPattern = "[aeiouAEIOU]";

        public List<string> ApplyFilters(string fileContent, FilterType filterType)
        {
            var matches = Matches(fileContent, @"\b\w+\b");
            var words = matches.Select(m => m.Value).ToList();
            var wordsToFilterOut = new List<string>();

            ApplyFilterOne(filterType, words, wordsToFilterOut);

            ApplyFilterTwo(filterType, words, wordsToFilterOut);

            ApplyFilterThree(filterType, words, wordsToFilterOut);

            return wordsToFilterOut;
        }

        private void ApplyFilterOne(FilterType filterType, List<string> wordsToFilter, List<string> filterWords)
        {
            if (filterType == FilterType.Filter1)
            {
                foreach (var word in wordsToFilter)
                {
                    if (IsVowelNearTheMiddle(word))
                    {
                        filterWords.Add(word);
                    }
                }
            }
        }

        private static void ApplyFilterTwo(FilterType filterType, List<string> wordsToFilter, List<string> filterWords)
        {
            if (filterType == FilterType.Filter2)
            {
                foreach (var word in wordsToFilter)
                {
                    if (word.Length < 3)
                    {
                        filterWords.Add(word);
                    }
                }
            }
        }

        private static void ApplyFilterThree(FilterType filterType, List<string> wordsToFilter, List<string> filterWords)
        {
            if (filterType == FilterType.Filter3)
            {
                filterWords.AddRange(wordsToFilter.Where(word => word.Contains('t', StringComparison.CurrentCultureIgnoreCase)));
            }
        }

        private bool IsVowelNearTheMiddle(string word)
        {
            var length = word.Length;
            var middleIndex = length / 2;
            if (length % 2 == 1)
            {
                var middleCharacter = word[middleIndex];
                return IsMatch(middleCharacter.ToString(), VowelMatchingPattern);
            }
            var middleChars = word.Substring(middleIndex - 1, 2);
            return IsMatch(middleChars, VowelMatchingPattern);
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
}