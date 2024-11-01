using FluentAssertions;
using TextFilter.Services.Derived;

namespace TextFilter.Tests
{
    public class VowelNearMiddleFilterTests
    {
        [Fact]
        public void IsNumberOddOrEven_Even_ReturnsFalse()
        {
            var result = VowelNearMiddleFilter.IsNumberOddOrEven(4);

            result.Should().BeFalse();
        }

        [Fact]
        public void IsNumberOddOrEven_Odd_ReturnsTrue()
        {
            var result = VowelNearMiddleFilter.IsNumberOddOrEven(5);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("Dry", false)]
        [InlineData("rhythm", false)]
        [InlineData("clean", true)]
        [InlineData("what", true)]
        [InlineData("currently", true)]
        [InlineData("the", false)]
        [InlineData("rather", false)]
        public void IsVowelNearTheMiddle_ListOfWordsToCheck_ReturnsExpectedBool(string word, bool expectResult)
        {
            var result = VowelNearMiddleFilter.IsVowelNearTheMiddle(word);

            result.Should().Be(expectResult);
        }
    }
}
