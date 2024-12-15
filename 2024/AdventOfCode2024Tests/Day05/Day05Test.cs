using AdventOfCode2024.Day05;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day04
{
    public class Day05Test
    {
        private readonly string _basePath = "Day05/Input";
        private readonly Resolve _resolve;

        public Day05Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Middle_Page_Summed()
        {
            string documentText = """
                47|53
                97|13
                97|61
                97|47
                75|29
                61|13
                75|53
                29|13
                97|29
                53|29
                61|53
                97|53
                61|29
                47|13
                75|47
                97|75
                47|61
                75|61
                47|29
                75|13
                53|13

                75,47,61,53,29
                97,61,53,29,13
                75,29,13
                75,97,47,61,53
                61,13,29
                97,13,75,29,47
                """;
            int middlePageSummed = _resolve.GetMiddlePageSummed(documentText.Split(Environment.NewLine).ToList());

            middlePageSummed.Should().Be(143);
        }

        [Fact]
        public void Get_Middle_Unorder_Page_Summed()
        {
            string documentText = """
                47|53
                97|13
                97|61
                97|47
                75|29
                61|13
                75|53
                29|13
                97|29
                53|29
                61|53
                97|53
                61|29
                47|13
                75|47
                97|75
                47|61
                75|61
                47|29
                75|13
                53|13

                75,47,61,53,29
                97,61,53,29,13
                75,29,13
                75,97,47,61,53
                61,13,29
                97,13,75,29,47
                """;
            int middleUnorderedPageSummed = _resolve.GetUnorderedMiddlePageSummed(documentText.Split(Environment.NewLine).ToList());

            middleUnorderedPageSummed.Should().Be(123);
        }

        [Fact]
        public void Get_Middle_Page_Summed_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int middlePageSummed = _resolve.GetMiddlePageSummed(document);

            middlePageSummed.Should().Be(5588);
        }
        [Fact]
        public void Get_Middle_Unorder_Page_Summed_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int middleUnorderedPageSummed = _resolve.GetUnorderedMiddlePageSummed(document);

            middleUnorderedPageSummed.Should().Be(5331);
        }
    }
}