using AdventOfCode2024.Day06;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day06
{
    public class Day06Test
    {
        private readonly string _basePath = "Day06/Input";
        private readonly Resolve _resolve;

        public Day06Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Max_Path_Step()
        {
            string documentText = """
                ....#.....
                .........#
                ..........
                ..#.......
                .......#..
                ..........
                .#..^.....
                ........#.
                #.........
                ......#...
                """;
            int maxPathStep = _resolve.GetMaxPathStep(documentText.Split(Environment.NewLine).ToList());

            maxPathStep.Should().Be(41);
        }
        [Fact]
        public void Get_Max_Obstruction_Path()
        {
            string documentText = """
                ....#.....
                .........#
                ..........
                ..#.......
                .......#..
                ..........
                .#..^.....
                ........#.
                #.........
                ......#...
                """;
            int maxObstructionPath = _resolve.GetMaxObstructionPath(documentText.Split(Environment.NewLine).ToList());

            maxObstructionPath.Should().Be(6);
        }
        [Fact]
        public void Get_Max_Path_Step_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int maxPathStep = _resolve.GetMaxPathStep(document);

            maxPathStep.Should().Be(4903);
        }
        //[Fact]
        public void Get_Max_Obstruction_Path_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int maxObstructionPath = _resolve.GetMaxObstructionPath(document);

            maxObstructionPath.Should().Be(1911);
        }
    }
}