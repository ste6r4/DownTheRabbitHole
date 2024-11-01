using TextFilter.Services.Interfaces;
using TextFilter.Shared;

namespace TextFilter.Services.Derived
{
    public class LengthFilter : IWordFilter
    {
        public List<string> Apply(List<string> words)
        {
            return words.Where(word => word.Length <AppConstants.CharacterLimitLessThanThree).ToList();
        }
    }
}