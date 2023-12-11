namespace AdventOfCode2023.Day01
{
    public class Trebuchet
    {
        private readonly Dictionary<string, string> _spelledAllowed = new()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3",
            ["four"] = "4",
            ["five"] = "5",
            ["six"] = "6",
            ["seven"] = "7",
            ["eight"] = "8",
            ["nine"] = "9"
        };
        public int GetCalibrationDocumentValue(List<string> lineOfText)
        {
            int calibrationDocumentValue = 0;
            foreach (string line in lineOfText)
            {
                var calibrationValue = GetCalibrationValue(line);
                calibrationDocumentValue += int.Parse(calibrationValue);
            }
            return calibrationDocumentValue;
        }

        public string GetCalibrationValue(string lineOfText)
        {
            var calculationValues = MatchCalculationValue(lineOfText);

            if (calculationValues.Count == 1)
            {
                var calculationValue = calculationValues.First();
                return $"{GetParsedCalibrationValue(calculationValue)}{GetParsedCalibrationValue(calculationValue)}";
            }

            return $"{GetParsedCalibrationValue(calculationValues.First())}{GetParsedCalibrationValue(calculationValues.Last())}";
        }

        private string GetParsedCalibrationValue(string calibrationValue)
            => _spelledAllowed.TryGetValue(calibrationValue, out var value) ? value : calibrationValue;

        private List<string> MatchCalculationValue(string lineOfText)
        {
            Dictionary<int, string> indexByValue = new Dictionary<int, string>();

            foreach (string calibrationSpelled in _spelledAllowed.Keys)
            {
                var occurences = lineOfText.AllIndexesOf(calibrationSpelled);
                foreach (int index in occurences)
                {
                    indexByValue.Add(index, calibrationSpelled);
                }
            }
            foreach (string calibration in _spelledAllowed.Values)
            {
                var occurences = lineOfText.AllIndexesOf(calibration);
                foreach (int index in occurences)
                {
                    indexByValue.Add(index, calibration);
                }
            }

            return indexByValue.OrderBy(i => i.Key).Select(i => i.Value).ToList();
        }
    }

    public static class StringExtension
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
