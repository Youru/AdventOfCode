using Advent2017;
using Advent2017.Day3;
using NFluent;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventTest
{
    public class AdventDay3Should
    {
        private AdventDay3 advent;

        public AdventDay3Should()
        {
            advent = new AdventDay3();
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
