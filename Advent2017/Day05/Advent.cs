using Advent2017.Extension;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Advent2017.Day05
{
    public class Advent
    {
        public int GetNumberStepToEscapeTheMaze(int[] mazeDetail)
        {
            var step = 0;
            var index = 0;
            while (index < mazeDetail.Length)
            {
                var value = mazeDetail[index];
                index += value;
                mazeDetail[index - value]++;
                step++;
            }

            return step;
        }

        public int GetNumberStepToEscapeTheMazeV2(int[] mazeDetail)
        {
            var step = 0;
            var index = 0;
            while (index < mazeDetail.Length)
            {
                var value = mazeDetail[index];
                index += value;
                mazeDetail[index - value] += value >= 3 ? -1 : 1;
                step++;
            }

            return step;
        }

    }
}
