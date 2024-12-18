namespace AdventOfCode2024.Day07
{
    public class Resolve
    {
        public long GetSumCorrectEquation(List<string> list)
        {
            long sum = 0;
            foreach (var item in list)
            {
                var equation = item.Split(':');
                var result = long.Parse(equation[0]);
                if (EquationIsCorrect(result, equation[1]))
                    sum += result;
            }

            return sum;
        }
        public long GetSumCorrectEquationWithThirdOperator(List<string> list)
        {
            long sum = 0;
            foreach (var item in list)
            {
                var equation = item.Split(':');
                var result = long.Parse(equation[0]);
                if (EquationIsCorrect(result, equation[1], hasThirdOperator: true))
                    sum += result;
            }

            return sum;
        }

        private bool EquationIsCorrect(long result, string lines, bool hasThirdOperator = false)
        {
            var numbers = lines.Trim().Split(' ').Select(int.Parse).ToArray();
            List<Possibility> possibilites = GetPossibilities(numbers, hasThirdOperator);
            List<string> equations = [];
            foreach (var item in possibilites)
            {
                var newItem = item;
                equations.Add(GetResult(newItem).equation.Trim());
            }
            return GetIfAtLeastOneEquationIsCorrect(result, equations.Distinct().ToList());
        }

        private static bool GetIfAtLeastOneEquationIsCorrect(long result, List<string> equations)
        {
            bool isCorrect = false;
            foreach (var equation in equations)
            {
                var member = equation.Split(' ');
                long value = int.Parse(member[0]);
                for (int i = 1; i < member.Length; i++)
                {
                    if (int.TryParse(member[i], out int memberValue)) continue;

                    if (member[i] is "x")
                        value *= long.Parse(member[i + 1]);
                    if (member[i] is "+")
                        value += long.Parse(member[i + 1]);
                    if (member[i] is "||")
                        value = long.Parse($"{value}{member[i + 1]}");
                };

                if (value == result)
                {
                    isCorrect = true;
                    break;
                };
            }

            return isCorrect;
        }

        private Possibility GetResult(Possibility item)
        {
            if (item.previous is null)
            {
                return item with { equation = $"{item.value} {item.equation}" };
            }

            return GetResult(item.previous with { equation = $"{item.operand} {item.value} {item.equation} " });
        }

        private List<Possibility> GetPossibilities(int[] numbers, bool hasThirdOperator = false)
        {
            List<Possibility> lastPossibilities = [];
            for (int i = 0; i < numbers.Count(); i++)
            {
                List<Possibility> newPossibilities = [];
                if (i == 0)
                {
                    lastPossibilities.Add(new(numbers[i], "x", null));
                    lastPossibilities.Add(new(numbers[i], "+", null));
                    if (hasThirdOperator)
                        lastPossibilities.Add(new(numbers[i], "||", null));
                }
                else
                {
                    foreach (var possibility in lastPossibilities)
                    {
                        newPossibilities.Add(new(numbers[i], "x", possibility));
                        newPossibilities.Add(new(numbers[i], "+", possibility));
                        if (hasThirdOperator)
                            newPossibilities.Add(new(numbers[i], "||", possibility));
                    }
                    lastPossibilities = [.. newPossibilities];
                }
            }

            return lastPossibilities;
        }
    }
    public record Possibility(int value, string operand, Possibility previous)
    {
        public string equation { get; set; }
    };
}
