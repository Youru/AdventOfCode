using Advent2017.Day02;
using NFluent;
using Xunit;

namespace AdventTest
{
    public class AdventDay2Should
    {
        private AdventDay advent;
        public AdventDay2Should()
        {
            advent = new AdventDay();
        }


        [Theory]
        [InlineData("5 1 9 5", 8)]
        [InlineData("7 5 3", 4)]
        [InlineData("2 4 6 8", 6)]
        public void GetCheksum1(string input, int resultExpected)
        {
            var result = advent.GetCheksum1(input);

            Check.That(result).Equals(resultExpected);
        }

        [Theory]
        [InlineData("5 9 2 8", 4)]
        [InlineData("9 4 7 3", 3)]
        [InlineData("3 8 6 5", 2)]
        public void GetCheksum2(string input, int resultExpected)
        {
            var result = advent.GetCheksum2(input);

            Check.That(result).Equals(resultExpected);
        }
    }
}
