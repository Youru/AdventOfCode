using Advent2017.Day11;
using NFluent;
using Xunit;

namespace AdventTest
{
    public class AdventDay11Should
    {
        private Advent advent;
        public AdventDay11Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("ne,ne,ne", 3)]
        [InlineData("ne,ne,sw,sw", 0)]
        [InlineData("ne,ne,s,s", 2)]
        [InlineData("se,sw,se,sw,sw", 3)]
        public void Get_The_Fewer_Number_Of_Step(string path, int stepExpected)
        {
            var hexes = advent.GetHexes(path);
            var step = advent.GetNumberStepToEscapeTheMaze(hexes);
            Check.That(step).Equals(stepExpected);
        }
    }
}
