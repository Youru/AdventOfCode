namespace AdventOfCode2024.Day01
{
    public class Resolve
    {
        public int GetSumEcart(List<string> lines)
        {
            int sumEcart = 0;
            List<int> firstColumn = [];
            List<int> secondColumn = [];
            for (int i = 0; i < lines.Count; i++)
            {
                var numbers = lines[i].Split("   ");
                firstColumn.Add(int.Parse(numbers[0]));
                secondColumn.Add(int.Parse(numbers[1]));
            }
            firstColumn = firstColumn.Order().ToList();
            secondColumn = secondColumn.Order().ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                sumEcart += Math.Abs(firstColumn[i] - secondColumn[i]);
            }
            return sumEcart;
        }

        public int GetSimilarityCode(List<string> lines)
        {
            int similarityCode = 0;
            List<string> firstColumn = [];
            Dictionary<string, int> numberByValue = new();
            for (int i = 0; i < lines.Count; i++)
            {
                var numbers = lines[i].Split("   ");
                numberByValue[numbers[1]] = !numberByValue.TryGetValue(numbers[1], out int value) ? 1 : ++value;
            }
            for (int i = 0; i < lines.Count; i++)
            {
                var numbers = lines[i].Split("   ");
                similarityCode += !numberByValue.TryGetValue(numbers[0], out int value) ? 0 : value * int.Parse(numbers[0]);
            }
            return similarityCode;
        }

    }
}
