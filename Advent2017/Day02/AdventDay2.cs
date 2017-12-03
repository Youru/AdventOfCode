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
            var numbers = GetSortInput(input);
            return numbers.Last() - numbers.First();
        }

        public int GetCheksum2(string input)
        {
            var numbers = GetSortInput(input);
            return numbers.Select(n1 => numbers.Select(n2 => (n1 != n2 && n1 % n2 == 0) ? n1 / n2 : 0).Sum()).Sum();
        }

        private List<int> GetSortInput(string input)
        {
            return (input.Split(' ').ToList().Select(x => int.Parse(x))).OrderBy(n=>n).ToList();
        }
    }
}
