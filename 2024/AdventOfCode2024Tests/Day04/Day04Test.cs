using AdventOfCode2024.Day04;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day04
{
    public class Day04Test
    {
        private readonly string _basePath = "Day04/Input";
        private readonly Resolve _resolve;

        public Day04Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Xmas_Number()
        {
            string documentText = """
                MMMSXXMASM
                MSAMXMSMSA
                AMXSXMAAMM
                MSAMASMSMX
                XMASAMXAMM
                XXAMMXXAMA
                SMSMSASXSS
                SAXAMASAAA
                MAMMMXMMMM
                MXMXAXMASX
                """;
            int xmasNumber = _resolve.GetXmasNumber(documentText.Split(Environment.NewLine).ToList());

            xmasNumber.Should().Be(18);
        }

        [Fact]
        public void Get_Mas_Number()
        {
            string documentText = """
                .M.S......
                ..A..MSMS.
                .M.S.MAA..
                ..A.ASMSM.
                .M.S.M....
                ..........
                S.S.S.S.S.
                .A.A.A.A..
                M.M.M.M.M.
                ..........
                """;
            int xmasNumber = _resolve.GetMasNumber(documentText.Split(Environment.NewLine).ToList());

            xmasNumber.Should().Be(9);
        }

        [Fact]
        public void Get_Xmas_Number_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int xmasNumber = _resolve.GetXmasNumber(document);

            xmasNumber.Should().Be(2447);
        }
        [Fact]
        public void Get_Mas_Number_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int xmasNumber = _resolve.GetMasNumber(document);

            xmasNumber.Should().Be(1868);
        }
    }
}