using Advent2017.Day01;
using NFluent;
using System.Linq;
using Xunit;

namespace AdventTest
{
    public class AdventDay1Should
    {
        private Advent advent;
        public AdventDay1Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void ResolvedCaptchaStep1(string input, int resultExpected)
        {
            var result = advent.GetSameDigitList(input, 1);

            Check.That(result.Sum()).Equals(resultExpected);
        }

        [Theory]
        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void ResolvedCaptchaStep2(string input, int resultExpected)
        {
            var step = advent.GetStep(input);
            var result = advent.GetSameDigitList(input, step);

            Check.That(result.Sum()).Equals(resultExpected);
        }
    }
}
