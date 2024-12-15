using AdventOfCode2023.Day04;
using AdventOfCode2023Tests.Common;
using FluentAssertions;

namespace AdventOfCode2023Tests.Day04
{
    public class ScratchcardsTest
    {
        private readonly Scratchcards _scratchcards;
        private readonly string _basePath = "Day04/Input";


        public ScratchcardsTest()
        {
            _scratchcards = new Scratchcards();
        }

        [Fact]
        public void Should_Get_8_Point_For_Card1()
        {
            string card = """
                Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
                """;

            var pointValue = _scratchcards.GetPointForCard(card);

            pointValue.Should().Be(8);
        }
        [Fact]
        public void Should_Get_13_Point_For_All_Card()
        {
            string cards = """
                Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
                Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
                Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
                Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
                Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
                Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
                """;

            var pointValueSummed = _scratchcards.GetSumPointForCards(cards.Split(Environment.NewLine).ToList());

            pointValueSummed.Should().Be(13);
        }
        [Fact]
        public void Should_Get_Points_For_All_Card_With_Input()
        {
            List<string> cards = FileHelper.GetContentByLine(_basePath, "Input1.txt");

            var pointValueSummed = _scratchcards.GetSumPointForCards(cards);

            pointValueSummed.Should().Be(21485);
        }
        [Fact]
        public void Should_Get_ScratchCard_Point_For_All_Card()
        {
            string cards = """
                Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
                Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
                Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
                Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
                Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
                Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
                """;

            var pointValueSummed = _scratchcards.GetWinningNumberByCards(cards.Split(Environment.NewLine).ToList());
            var occurenceByCard = _scratchcards.GetOccurrenceByCard(pointValueSummed);
            var sum = occurenceByCard.Select(o=>o.Value).Sum();

            sum.Should().Be(30);
        }
        [Fact]
        public void Should_ScratchCard_Point_For_All_Card_With_Input()
        {
            List<string> cards = FileHelper.GetContentByLine(_basePath, "Input1.txt");

            var pointValueSummed = _scratchcards.GetWinningNumberByCards(cards);
            var occurenceByCard = _scratchcards.GetOccurrenceByCard(pointValueSummed);
            var sum = occurenceByCard.Select(o => o.Value).Sum();

            sum.Should().Be(11024379);
        }
    }
}
