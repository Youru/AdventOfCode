using AdventOfCode2024.Day10;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day10
{
    public class Day10Test
    {
        private readonly string _basePath = "Day10/Input";
        private readonly Resolve _resolve;

        public Day10Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Trailhead_Score()
        {
            string documentText = """
                ..90..9
                ...1.98
                ...2..7
                6543456
                765.987
                876....
                987....
                """;
            long fileSystemChecksum = _resolve.GetTrailheadScore(documentText.Split(Environment.NewLine).ToList());

            fileSystemChecksum.Should().Be(4);
        }
        [Fact]
        public void Get_Trailhead_Score_Without_Distinct()
        {
            string documentText = """
                ..90..9
                ...1.98
                ...2..7
                6543456
                765.987
                876....
                987....
                """;
            long fileSystemChecksum = _resolve.GetTrailheadScore(documentText.Split(Environment.NewLine).ToList(), false);

            fileSystemChecksum.Should().Be(13);
        }
        [Fact]
        public void Get_Trailhead_Score_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            long fileSystemChecksum = _resolve.GetTrailheadScore(document);

            fileSystemChecksum.Should().Be(501);
        }
        [Fact]
        public void Get_Trailhead_Score_Without_Distinct_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            long fileSystemChecksum = _resolve.GetTrailheadScore(document,false);

            fileSystemChecksum.Should().Be(501);
        }
    }
}