
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03
{
    public class Resolve
    {
        public int GetMultiplicationResult(List<string> list)
        {
            var regex = "(mul\\((\\d+,\\d+)\\))";
            int totalSum = 0;
            foreach (var item in list)
            {
                var matches = Regex.Matches(item, regex);
                foreach (Match match in matches)
                {
                    var numbers = match.Groups[2].Value.Split(',').Select(int.Parse).ToList();
                    totalSum += numbers[0] * numbers[1];
                }
            }
            return totalSum;
        }
        public int GetMultiplicationResultWithCondition(List<string> list)
        {
            var regex = "(mul\\((\\d+,\\d+)\\))|don\\'t\\(\\)|do\\(\\)";
            int totalSum = 0;
            Operation lastCondition = Operation.Do;
            foreach (var item in list)
            {
                var matches = Regex.Matches(item, regex);
                foreach (Match match in matches)
                {
                    Operation operation = GetOperation(match.Value);
                    if (operation is not Operation.Mul)
                        lastCondition = operation;
                    if (lastCondition is Operation.Dont || operation is not Operation.Mul)
                        continue;
                    var numbers = match.Groups[2].Value.Split(',').Select(int.Parse).ToList();
                    totalSum += numbers[0] * numbers[1];
                }
            }
            return totalSum;
        }

        private Operation GetOperation(string value)
        {
            if (value.Contains("mul"))
                return Operation.Mul;
            if (value.Contains("don"))
                return Operation.Dont;
            if (value.Contains("do"))
                return Operation.Do;

            return Operation.Mul;
        }
    }
    public enum Operation
    {
        Mul,
        Dont,
        Do
    }
}
