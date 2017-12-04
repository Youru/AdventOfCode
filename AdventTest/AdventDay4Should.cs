using Advent2017.Day04;
using NFluent;
using Xunit;

namespace AdventTest
{
    public class AdventDay4Should
    {
        private Advent advent;

        public AdventDay4Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void Verify_If_PassPhrase_Doesnt_Contains_The_Same_Word_Twice(string passphrase, bool validityExpected)
        {
            var isValid = advent.GetPassPhraseWithoutDuplicateValidity(passphrase);
            Check.That(isValid).Equals(validityExpected);
        }

        [Theory]
        [InlineData("abcde fghij", true)]
        [InlineData("abcde xyz ecdab", false)]
        [InlineData("a ab abc abd abf abj", true)]
        [InlineData("iiii oiii ooii oooi oooo", true)]
        [InlineData("oiii ioii iioi iiio", false)]
        public void Verify_If_PassPhrase_Doesnt_Contains_Anagram_Word(string passphrase, bool validityExpected)
        {
            var isValid = advent.GetPassPhraseWithoutAnagramValidity(passphrase);
            Check.That(isValid).Equals(validityExpected);
        }
    }
}
