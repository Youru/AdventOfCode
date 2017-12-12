using Advent2017;
using Advent2017.Day12;
using NFluent;
using Xunit;

namespace AdventTest
{
    public class AdventDay12Should
    {
        private Advent advent;
        public AdventDay12Should()
        {
            advent = new Advent();
        }

        [Fact]
        public void Get_All_Programs_On_Zero_Group()
        {
            var reader = new ReadFile();
            var lines = reader.GetContentByLine("Day12ExFile");

            var nodes = advent.GetNodes(lines);
            var nodeInSameGroup = advent.GetNodesInSameGroup(nodes, 0);

            Check.That(nodeInSameGroup.Count).Equals(6);
        }

        [Fact]
        public void Get_Number_Group()
        {
            var reader = new ReadFile();
            var lines = reader.GetContentByLine("Day12ExFile");

            var nodes = advent.GetNodes(lines);
            var numberGroup = advent.GetNumberGroup(nodes, 0);

            Check.That(numberGroup).Equals(2);
        }
    }
}
