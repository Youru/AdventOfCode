using Advent2017.Day06;
using NFluent;
using Xunit;

namespace AdventTest
{
    public class AdventDay6Should
    {
        private Advent advent;

        public AdventDay6Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("0 2 7 0", 5)]
        public void Get_Cycle_Number_To_Reach_Infinite_Loop(string maze, int resultExpected)
        {
            var result = advent.GetNumberRedistributionCycle(maze);

            Check.That(result).Equals(resultExpected);
        }

        [Theory]
        [InlineData("0 2 7 0", 4)]
        public void Get_Cycle_Number_Between_Duplicate(string maze, int resultExpected)
        {
            var result = advent.GetCycleNumberBetweenDuplicate(maze);

            Check.That(result).Equals(resultExpected);
        }        
    }
}
