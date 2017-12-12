using Advent2017.Day05;
using NFluent;
using System.Linq;
using Xunit;

namespace AdventTest
{
    public class AdventDay05Should
    {
        private Advent advent;

        public AdventDay05Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("0 3 0 1 -3", 5)]
        public void Escape_The_Maze_In_X_Step(string maze, int stepToExitExpected)
        {
            var mazeDetail = maze.Split(' ').Select(x => int.Parse(x)).ToArray();
            var numberStep = advent.GetNumberStepToEscapeTheMaze(mazeDetail);
            Check.That(numberStep).Equals(stepToExitExpected);
        }

        [Theory]
        [InlineData("0 3 0 1 -3", 10)]
        public void Escape_The_Maze_In_More_Step(string maze, int stepToExitExpected)
        {
            var mazeDetail = maze.Split(' ').Select(x => int.Parse(x)).ToArray();
            var numberStep = advent.GetNumberStepToEscapeTheMazeWithSpecialRule(mazeDetail);
            Check.That(numberStep).Equals(stepToExitExpected);
        }
    }
}
