using TextFilter.Services.Interfaces;
using TextFilter.Shared;

namespace TextFilter.Services.Derived
{
    public class ContainsLetterFilter : IWordFilter
    {
        public List<string> Apply(List<string> words)
        {
            return words.Where(word => word.Contains(AppConstants.LetterToSearchForBasedOnT,
                StringComparison.CurrentCultureIgnoreCase)).ToList();
        }
    }
}
