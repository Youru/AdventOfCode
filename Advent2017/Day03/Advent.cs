using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2017.Day03
{
    public class Advent
    {
        private SquarePosition position;

        public Advent() { position = new SquarePosition(); }

        public int GetStepToCarryDataFromSquareToOrigin(int square)
        {
            var currentPosition = new Square(0, 0);
            var dictionnaryPosition = new Dictionary<string, int>() { [currentPosition.Position] = 1 };

            for (var i = 2; i <= square; i++)
            {
                currentPosition = position.GetNext(dictionnaryPosition, currentPosition);

                dictionnaryPosition[currentPosition.Position] = i;
            }

            return Math.Abs(currentPosition.X) + Math.Abs(currentPosition.Y);
        }

        public int GetValueLargerThanPuzzleInput(int puzzleInput)
        {
            var currentPosition = new Square(0, 0);
            var dictionnaryPosition = new Dictionary<string, int>() { [currentPosition.Position] = 1 };
            var value = 1;

            while (value < puzzleInput)
            {
                currentPosition = position.GetNext(dictionnaryPosition, currentPosition);
                value = SumValueFromNeighbours(currentPosition, dictionnaryPosition);

                dictionnaryPosition[currentPosition.Position] = value;
            }

            return value;
        }

        private int SumValueFromNeighbours(Square currentPosition, Dictionary<string, int> dictionnaryPosition)
            => currentPosition.Neighbours.Select(n => dictionnaryPosition.ContainsKey(n) ? dictionnaryPosition[n] : 0).Sum();
    }
}
