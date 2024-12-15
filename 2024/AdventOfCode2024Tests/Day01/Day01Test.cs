using AdventOfCode2024.Day01;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day01
{
    public class Day01Test
    {
        private readonly string _basePath = "Day01/Input";
        private readonly Resolve _resolve;

        public Day01Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Correct_Sum_Ecart()
        {
            string documentText = """
                3   4
                4   3
                2   5
                1   3
                3   9
                3   3
                """;
            List<string> lines = documentText.Split(Environment.NewLine).ToList();
            var sumEcart = _resolve.GetSumEcart(documentText.Split(Environment.NewLine).ToList());

            sumEcart.Should().Be(11);
        }
        [Fact]
        public void Get_Correct_Similarity_Code()
        {
            string documentText = """
                3   4
                4   3
                2   5
                1   3
                3   9
                3   3
                """;
            List<string> lines = documentText.Split(Environment.NewLine).ToList();
            var similiratyCode = _resolve.GetSimilarityCode(documentText.Split(Environment.NewLine).ToList());

            similiratyCode.Should().Be(31);
        }
        [Fact]
        public void Get_Correct_Sum_Ecart_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            var sumEcart = _resolve.GetSumEcart(document);

            sumEcart.Should().Be(1651298);
        }
        [Fact]
        public void Get_Correct_Similarity_Code_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            var similiratyCode = _resolve.GetSimilarityCode(document);

            similiratyCode.Should().Be(21306195);
        }
    }
}