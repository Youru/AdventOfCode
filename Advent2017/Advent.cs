using System;
using System.Collections.Generic;
using System.Linq;
namespace Advent2017
{
    public class Advent
    {
        public int GetStep(string input)
        {
            return input.Length / 2;
        }

        public List<int> GetSameDigitnumberList(string input, int step)
        {
            var SameDigitNumberList = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == (input[(i + step) % input.Length]))
                {
                    SameDigitNumberList.Add((int)Char.GetNumericValue(input[i]));
                }
            }

            return SameDigitNumberList;
        }
    }
}
