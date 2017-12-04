using System;
using System.Collections.Generic;
namespace Advent2017.Day01
{
    public class Advent
    {
        public int GetStep(string input) => input.Length / 2;

        public List<int> GetSameDigitList(string input, int step)
        {
            var SameDigitList = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == (input[(i + step) % input.Length]))
                {
                    SameDigitList.Add((int)Char.GetNumericValue(input[i]));
                }
            }

            return SameDigitList;
        }
    }
}
