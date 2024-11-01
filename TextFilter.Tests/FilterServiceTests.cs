using FluentAssertions;
using TextFilter.Services.Derived;
using TextFilter.Services.Interfaces;
using TextFilter.Shared;

namespace TextFilter.Tests
{
    public class FilterServiceTests
    {
        private readonly FilterService _filterService = new();
        private readonly string _fileContent = Services.Helpers.FileHelper.GetFileContent(Directory.GetCurrentDirectory(), AppConstants.TextInputFileName); 

        [Theory]
        [InlineData("Dry", "Dry")]
        [InlineData("rhythm", "rhythm")]
        [InlineData("clean", "")]
        [InlineData("what", "")]
        [InlineData("currently", "")]
        [InlineData("the", "the")]
        [InlineData("rather", "rather")]
        [InlineData("cupboards", "")]
        [InlineData("tunnel", "tunnel")]
        [InlineData("without", "without")]
        [InlineData("pictures", "")]
        [InlineData("reading", "reading")]
        [InlineData("whether", "whether")]
        [InlineData("killing", "killing")]
        [InlineData("MARMALADE", "")]
        [InlineData("considering", "considering")]
        [InlineData("conversations", "conversations")]
        [InlineData("disappointment", "")]
        public void ApplyFilters_Filter1VowelNearMiddleFilter_ReturnsTextWithoutVowelsInTheMiddleOfTheWord(string textToFilter, string expectResult)
        {
            var result = _filterService.ApplyFilters(new VowelNearMiddleFilter(), textToFilter);

            result.Should().NotContain(expectResult);
        }

        [Theory]
        [InlineData("at", "")]
        [InlineData("the", "the")]
        [InlineData("what", "what")]
        [InlineData("clean", "clean")]
        [InlineData("Alice was beginning to get very tired of sitting by her sister on the bank", "Alice was beginning  get very tired  sitting  her sister  the bank")]
        public void ApplyFilters_Filter2LengthFilterApplied_ReturnsTextWithoutWordsHavingLessThanThreeLetters(string textToFilter, string expectResult)
        {
            var result = _filterService.ApplyFilters(new LengthFilter(), textToFilter);

            result.Should().NotContain(expectResult);
        }

        [Theory]
        [InlineData("what", "")]
        [InlineData("clean", "clean")]
        [InlineData("currently", "")]
        [InlineData("the", "")]
        [InlineData("rather", "")]
        [InlineData("whaT", "")]
        [InlineData("Alice was beginning to get very tired of sitting by her sister 'on' the bank", "Alice was beginning   very  of  by her  'on'  bank")]       
        public void ApplyFilters_Filter3ContainsLetterFilterApplied_ReturnsTextWithoutLetterT(string textToFilter, string expectResult)
        {
            var result = _filterService.ApplyFilters(new ContainsLetterFilter(), textToFilter);

            result.Should().NotContain(expectResult);
        }

        [Fact]
        public void Apply_Filter1Applied_ReturnsListOfFilteredOutWords()
        {
            var result = _filterService.ApplyFilters(new VowelNearMiddleFilter(), _fileContent);

            result.Count.Should().Be(327);
        }

        [Fact]
        public void Apply_Filter2Applied_ReturnsListOfFilteredOutWords()
        {
            var result = _filterService.ApplyFilters(new LengthFilter(), _fileContent);

            result.Should().NotBeNullOrEmpty();
            result.Count(x => x.Length < AppConstants.CharacterLimitLessThanThree).Should().Be(101);
        }

        [Fact]
        public void Apply_Filter3Applied_ReturnsListOfFilteredOutWords()
        {
            var result = _filterService.ApplyFilters(new ContainsLetterFilter(), _fileContent);

            result.Count(x => x.Contains(AppConstants.LetterToSearchForBasedOnT, StringComparison.OrdinalIgnoreCase)).Should().Be(178);
        }

        [Fact]
        public void ApplyFilters_NoFilters_ReturnsOriginalContent()
        {
            var filterService = new FilterService();
            var fileContent = "This is a test content.";

            var result = filterService.ApplyFilters(fileContent);

            result.Should().Be(fileContent);
        }

        [Fact]
        public void ApplyFilters_AllFiltersAndFullTextInput_StringReturnedWithFilteredWordsRemoved()
        {
            var filters = new List<IWordFilter> { new LengthFilter(), new ContainsLetterFilter(), new VowelNearMiddleFilter() };
            var filterService = new FilterService(filters);

            var result = filterService.ApplyFilters(_fileContent);

            result.Should().Be(TestConstants.ExpectContent);
        }
    }
}