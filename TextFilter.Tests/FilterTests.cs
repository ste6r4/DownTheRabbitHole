using FluentAssertions;

namespace TextFilter.Tests
{
    public class FilterTests
    {
        private readonly Filter _filter = new();
        private string _fileContent =  FileHelper.GetFileContent(); 

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
        public void Apply_Filter3Applied_ReturnsTextWithoutVowelsInTheMiddleOfTheWord(string textToFilter, string expectResult)
        {
            var result = _filter.ApplyFilters(textToFilter, FilterType.Filter1);

            result.Should().NotContain(expectResult);
        }

        [Theory]
        [InlineData("at", "")]
        [InlineData("the", "the")]
        [InlineData("what", "what")]
        [InlineData("clean", "clean")]
        [InlineData("Alice was beginning to get very tired of sitting by her sister on the bank", "Alice was beginning  get very tired  sitting  her sister  the bank")]
        public void Apply_Filter2Applied_ReturnsTextWithoutWordsHavingLessThanThreeLetters(string textToFilter, string expectResult)
        {
            var result = _filter.ApplyFilters(textToFilter, FilterType.Filter2);

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
        public void Apply_Filter3Applied_ReturnsTextWithoutLetterT(string textToFilter, string expectResult)
        {
            var result = _filter.ApplyFilters(textToFilter, FilterType.Filter3);

            result.Should().NotContain(expectResult);
        }

        [Fact]
        public void Apply_Filter1Applied_ReturnsListOfFilteredOutWords()
        {
            var result = _filter.ApplyFilters(_fileContent, FilterType.Filter1);

            result.Count.Should().Be(327);
        }

        [Fact]
        public void Apply_Filter2Applied_ReturnsListOfFilteredOutWords()
        {
            var result = _filter.ApplyFilters(_fileContent, FilterType.Filter2);

            result.Should().NotBeNullOrEmpty();
            result.Count(x => x.Length < 3).Should().Be(101);
        }

        [Fact]
        public void Apply_Filter3Applied_ReturnsListOfFilteredOutWords()
        {
            var result = _filter.ApplyFilters(_fileContent, FilterType.Filter3);
            
            result.Count(x => x.Contains('t', StringComparison.OrdinalIgnoreCase)).Should().Be(178);
        }
    }
}