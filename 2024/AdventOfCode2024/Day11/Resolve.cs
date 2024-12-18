using AdventOfCode2024.Day05;
using AdventOfCode2024.Shared;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode2024.Day11
{
    public class Resolve
    {
        private readonly Dictionary<NumberBlink, long> _numberBlinks = [];
        public long GetNumberOfStone(string field, int blink = 25)
        {
            List<long> numbers = field.Split(" ").Select(long.Parse).ToList();
            long count = numbers.Select(s => CountStone(s, blink)).Sum();
            return count;
        }

        private long Amount(long stone, int blinkLeft)
        {
            var minusBlinkLeft = blinkLeft - 1;
            var stoneString = stone.ToString();
            if (stone == 0)
                return CountStone(1, minusBlinkLeft);
            else if (stoneString.Length % 2 == 0)
            {
                var leftPart = stoneString[..(stoneString.Length / 2)];
                var rightPart = stoneString[(stoneString.Length / 2)..];
                return CountStone(long.Parse(leftPart), minusBlinkLeft) + CountStone(long.Parse(rightPart), minusBlinkLeft);
            }
            else
                return CountStone(stone * 2024, minusBlinkLeft);

        }

        private long CountStone(long stone, int blinkLeft)
        {
            if (blinkLeft == 0) return 1;

            NumberBlink key = new(stone, blinkLeft);
            if (_numberBlinks.TryGetValue(key, out var result))
                return result;

            _numberBlinks[key] = Amount(stone, blinkLeft);
            return _numberBlinks[key];
        }

        public record NumberBlink(long number, int blink);

    }