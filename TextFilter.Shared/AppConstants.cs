namespace TextFilter.Shared
{
    public static class AppConstants
    {
        public const string TextInputFileName = "TextInput.txt";

        public const char LetterToSearchForBasedOnT = 't';

        public const int CharacterLimitLessThanThree = 3;


        public static class RegexPatterns 
        {
            public const string VowelMatches = "[aeiouAEIOU]";

            public const string CompleteWords = @"\b\w+\b";
        }
    }
}
