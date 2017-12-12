using Advent2017;
using Advent2017.Day12;
using NFluent;
using System.Linq;
using Xunit;
using System;
using System.Collections.Generic;

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

            var Nodes = advent.GetNodes(lines);
            var visitedNodes = advent.GetVisitedNodes(Nodes, 0);

            Check.That(visitedNodes.Count).Equals(6);
        }

        [Fact]
        public void Get_Number_Group()
        {
            var reader = new ReadFile();
            var lines = reader.GetContentByLine("Day12ExFile");

            var programGroups = advent.GetNodes(lines);
            var numberGroup = advent.GetNumberGroup(programGroups, 0);

            Check.That(numberGroup).Equals(2);
        }
    }
}
