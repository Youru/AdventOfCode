using AdventOfCode2024.Day11;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day11
{
    public class Day11Test
    {
        private readonly string _basePath = "Day11/Input";
        private readonly Resolve _resolve;

        public Day11Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Number_Of_Stone()
        {
            string documentText = """
                125 17
                """;
            long numberOfStone = _resolve.GetNumberOfStone(documentText, 6);

            numberOfStone.Should().Be(22);
        }
        [Fact]
        public void Get_Number_Of_Stone_From_Input()
        {
            string document = FileHelper.GetContent(_basePath, "Input1.txt");
            long numberOfStone = _resolve.GetNumberOfStone(document);

            numberOfStone.Should().Be(229043);
        }
        [Fact]
        public void Get_Number_Of_Stone_Long_Path_From_Input()
        {
            string document = FileHelper.GetContent(_basePath, "Input1.txt");
            long numberOfStone = _resolve.GetNumberOfStone(document, 75);

            numberOfStone.Should().Be(229043);
        }
    }
}