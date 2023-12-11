using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day04
{
    public class Scratchcards
    {
        public int GetSumPointForCards(List<string> cards)
        {
            int sum = 0;
            foreach (var card in cards)
            {
                sum += GetPointForCard(card);
            }
            return sum;
        }
        public int GetPointForCard(string card)
        {
            CardDetail cardDetail = GetCardDetail(card);

            var occurrenceNumberFound = 0;
            foreach (var number in cardDetail.Numbers)
            {
                if (cardDetail.WinningNumbers.Contains(number))
                    occurrenceNumberFound++;
            }

            return occurrenceNumberFound == 0 ? 0 : GetPoint(occurrenceNumberFound);
        }
        public Dictionary<int, List<int>> GetWinningNumberByCards(List<string> cards)
        {
            Dictionary<int, List<int>> ScratchcardsbyWinningNumber = new();

            for (int i = 0; i < cards.Count; i++)
            {
                var occurrence = GetWinningOccurrenceForCard(cards[i]);
                List<int> Scratchcards = GetScratchcards(i + 1, occurrence);
                ScratchcardsbyWinningNumber.Add(i + 1, Scratchcards);
            }
            return ScratchcardsbyWinningNumber;
        }

        private List<int> GetScratchcards(int cardId, int occurrence)
        {
            List<int> Scratchcards = new();
            for (int i = 1; i <= occurrence; i++)
            {
                Scratchcards.Add(cardId + i);
            }
            return Scratchcards;
        }

        public int GetWinningOccurrenceForCard(string card)
        {
            CardDetail cardDetail = GetCardDetail(card);

            var occurrenceNumberFound = 0;
            foreach (var number in cardDetail.Numbers)
            {
                if (cardDetail.WinningNumbers.Contains(number))
                    occurrenceNumberFound++;
            }

            return occurrenceNumberFound;
        }

        private int GetPoint(int occurrenceNumberFound)
        {
            if (occurrenceNumberFound == 1) return 1;
            int point = 1;
            for (int i = 0; i < occurrenceNumberFound - 1; i++)
            {
                point *= 2;
            }
            return point;
        }

        private CardDetail GetCardDetail(string card)
        {
            int indexOfCardSeparator = card.IndexOf(':');
            List<string> cardsRawDetail = card.Substring(indexOfCardSeparator).Split('|').ToList();
            return new()
            {
                WinningNumbers = GetNumber(cardsRawDetail[0]),
                Numbers = GetNumber(cardsRawDetail[1]),
            };
        }

        private List<int> GetNumber(string carRawDetail)
        {
            string pattern = "\\d+";
            var matches = Regex.Matches(carRawDetail, pattern);
            var numbers = matches.Select(m => int.Parse(m.Value));
            return numbers.ToList();
        }

        public Dictionary<int, int> GetOccurrenceByCard(Dictionary<int, List<int>> pointValueSummed)
        {
            Dictionary<int, int> occurrenceByCard = new();
            var pointValueSummedReversed = pointValueSummed.Reverse();
            foreach (var pointValue in pointValueSummedReversed)
            {
                UpdateoccurrenceByCard(occurrenceByCard, pointValue.Key);

                if (pointValue.Value.Any())
                    CalculPoint(pointValue.Value);
            }
            return occurrenceByCard;

            void CalculPoint(List<int> pointValues)
            {
                foreach (var pointValue in pointValues)
                {
                    UpdateoccurrenceByCard(occurrenceByCard, pointValue);
                    CalculPoint(pointValueSummed[pointValue]);
                }
            }

        }

        private static void UpdateoccurrenceByCard(Dictionary<int, int> occurrenceByCard, int pointValue)
        {
            occurrenceByCard[pointValue] = occurrenceByCard.TryGetValue(pointValue, out int value) ? ++value : 1;
        }
    }

    public struct CardDetail
    {
        public List<int> WinningNumbers { get; set; }
        public List<int> Numbers { get; set; }
    }
}
