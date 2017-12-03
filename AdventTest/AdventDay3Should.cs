using Advent2017.Day03;
using NFluent;
using Xunit;

namespace AdventTest
{
    public class AdventDay3Should
    {
        private AdventDay advent;

        public AdventDay3Should()
        {
            advent = new AdventDay();
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void GetStepToCarryDataFromSquare(int square, int stepExpexted)
        {
            var step = advent.GetStepToCarryDataFromSquareToOrigin(square);
            Check.That(step).Equals(stepExpexted);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(277678)]
        public void GetValueLargerThanPuzzleInput(int puzzleInput)
        {
            var value = advent.GetValueLargerThanPuzzleInput(puzzleInput);
            Check.That(value).IsStrictlyGreaterThan(puzzleInput);
        }
    }
}
