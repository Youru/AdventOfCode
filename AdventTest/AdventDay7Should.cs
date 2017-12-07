using Advent2017;
using Advent2017.Day07;
using NFluent;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventTest
{
    public class AdventDay7Should
    {
        private Advent advent;

        public AdventDay7Should()
        {
            advent = new Advent();
        }


        [Theory]
        [InlineData("pbga (66)", 66)]
        [InlineData("xhth (57)", 57)]
        [InlineData("ktlj (57)", 57)]
        [InlineData("fwft (72) -> ktlj, cntj, xhth", 72)]
        public void Get_Program_And_Their_Weight(string programDetail, int weightExpected)
        {
            var detail = advent.GetProgramDetail(programDetail);

            Check.That(detail.Weight).Equals(weightExpected);
        }

        [Theory]
        [InlineData("fwft (72) -> ktlj, cntj, xhth", 3)]
        [InlineData("fwft (72) -> ktlj, xhth", 2)]
        [InlineData("fwft (72) -> ktlj", 1)]
        public void Get_Program_And_Their_Children(string programDetail, int numberExpected)
        {
            var detail = advent.GetProgramDetail(programDetail);

            Check.That(detail.Children.Count).Equals(numberExpected);
        }

        [Fact]
        public void Get_The_Bottom_Program()
        {
            var reader = new ReadFile();
            var listProgramm = new List<Program>();
            var lines = reader.GetContentByLine("Day7ExFile");

            foreach (var line in lines)
            {
                listProgramm.Add(advent.GetProgramDetail(line));
            }

            var bottomProgram = advent.GetBottomProgram(listProgramm);

            Check.That(bottomProgram.Name).Equals("tknk");
        }

        [Theory]
        [InlineData("ugml", 251)]
        [InlineData("padx", 243)]
        [InlineData("fwft", 243)]
        public void Get_The_Total_Weight(string name, int totalWeightExpected)
        {
            var reader = new ReadFile();
            var listProgram = new List<Program>();
            var lines = reader.GetContentByLine("Day7ExFile");

            foreach (var line in lines)
            {
                listProgram.Add(advent.GetProgramDetail(line));
            }

            listProgram = advent.ListProgramUpdated(listProgram);
            var program = listProgram.First(lp => lp.Name == name);

            Check.That(program.Children.Sum(c => c.Weight) + program.Weight).Equals(totalWeightExpected);
        }

        [Theory]
        [InlineData("tknk", 8)]
        public void Get_The_Balance_Weight(string name, int balanceWeightExpected)
        {
            var reader = new ReadFile();
            var listProgram = new List<Program>();
            var lines = reader.GetContentByLine("Day7ExFile");

            foreach (var line in lines)
            {
                listProgram.Add(advent.GetProgramDetail(line));
            }

            listProgram = advent.ListProgramUpdated(listProgram);
            var program = advent.GetTheUnbalancedTower(listProgram);

            Check.That(program.Children.Select(c => c.TotalWeight).Max() - program.Children.Select(c => c.TotalWeight).Min()).Equals(balanceWeightExpected);
        }

    }
}
