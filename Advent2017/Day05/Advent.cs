using System;

namespace Advent2017.Day05
{
    public class Advent
    {
        public int GetNumberStepToEscapeTheMaze(int[] mazeDetail)
        {
            return GetNumberStepToEscapeTheMaze(mazeDetail, (value) => 1 );
        }

        public int GetNumberStepToEscapeTheMazeWithSpecialRule(int[] mazeDetail)
        {
            return GetNumberStepToEscapeTheMaze(mazeDetail, (value) => value >= 3 ? -1 : 1);
        }

        private int GetNumberStepToEscapeTheMaze(int[] mazeDetail, Func<int, int> calcul)
        {
            var step = 0;
            var index = 0;
            while (index < mazeDetail.Length)
            {
                var value = mazeDetail[index];
                index += value;
                mazeDetail[index - value] += calcul(value);
                step++;
            }

            return step;
        }

    }
}
