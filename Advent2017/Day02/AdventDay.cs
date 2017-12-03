using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent2017.Day02
{
    public class AdventDay
    {
        public int GetCheksum1(string input)
        {
            var numbers = GetSortedInput(input);
            return numbers.Last() - numbers.First();
        }

        public int GetCheksum2(string input)
        {
            var numbers = GetSortedInput(input);
            return GetLinesSum(numbers);
        }

        private List<int> GetSortedInput(string input) => (input.Split(' ').ToList().Select(x => int.Parse(x))).OrderBy(n => n).ToList();
        private int GetLinesSum(List<int> numbers) => numbers.Select(n1 => GetDivisibleNumberSum(numbers, n1)).Sum();
        private int GetDivisibleNumberSum(List<int> numbers, int n1) => numbers.Select(n2 => (n1 != n2 && n1 % n2 == 0) ? n1 / n2 : 0).Sum();
    }
}
