using AdventOfCode2024.Day02;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day02
{
    public class Day02Test
    {
        private readonly string _basePath = "Day02/Input";
        private readonly Resolve _resolve;

        public Day02Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Safe_Report()
        {
            string documentText = """
                7 6 4 2 1
                1 2 7 8 9
                9 7 6 2 1
                1 3 2 4 5
                8 6 4 4 1
                1 3 6 7 9
                """;
            int safeReportNumber = _resolve.GetSafeReportNumber(documentText.Split(Environment.NewLine).ToList());

            safeReportNumber.Should().Be(2);
        }
        [Fact]
        public void Get_Safe_Report_With_Dampener()
        {
            string documentText = """
                7 6 4 2 1
                1 2 7 8 9
                9 7 6 2 1
                1 3 2 4 5
                8 6 4 4 1
                1 3 6 7 9
                """;
            int safeReportNumber = _resolve.GetSafeReportNumberWithDampener(documentText.Split(Environment.NewLine).ToList());

            safeReportNumber.Should().Be(4);
        }
        [Fact]
        public void Get_Safe_Report_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            var safeReportNumber = _resolve.GetSafeReportNumber(document);

            safeReportNumber.Should().Be(463);
        }
        [Fact]
        public void Get_Safe_Report_With_Dampener_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            var safeReportNumber = _resolve.GetSafeReportNumberWithDampener(document);

            safeReportNumber.Should().Be(514);
        }
    }
}