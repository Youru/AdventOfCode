using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Advent2017.Day3;

namespace Advent2017
{
    public class AdventDay3
    {
        private Position position;
        private Direction direction;
        private Dictionary<PositionStruct, int> dictionnaryPosition;
        private DirectionEnum currentDirection;
        private PositionStruct currentPosition;

        public AdventDay3()
        {
            position = new Position();
            direction = new Direction();
            currentDirection = DirectionEnum.Right;
            currentPosition = new PositionStruct(0, 0);
            dictionnaryPosition = new Dictionary<PositionStruct, int>() { [currentPosition] = 1 };
        }

        public int GetStepToCarryDataFromSquareToOrigin(int square)
        {
            for (var i = 2; i <= square; i++)
            {
                GoToNextPosition();

                dictionnaryPosition[currentPosition] = i;
            }

            return Math.Abs(currentPosition.X) + Math.Abs(currentPosition.Y);
        }

        public int GetValueLargerThanPuzzleInput(int puzzleInput)
        {
            var value = 1;

            while (value < puzzleInput)
            {
                GoToNextPosition();
                value = SumValueFromNeighbours(currentPosition, dictionnaryPosition);

                dictionnaryPosition[currentPosition] = value;
            }

            return value;
        }
        
        private void GoToNextPosition()
        {
            currentDirection = dictionnaryPosition.Count > 1 ?
                                    direction.ChooseNextDirection(currentDirection, currentPosition.X, currentPosition.Y, dictionnaryPosition)
                                    : DirectionEnum.Right;
            currentPosition = position.CalculPosition(currentPosition.X, currentPosition.Y, currentDirection);
        }

        private int SumValueFromNeighbours(PositionStruct currentPosition, Dictionary<PositionStruct, int> dictionnaryPosition)
        {
            return currentPosition.Neighbours.Select(n => dictionnaryPosition.ContainsKey(n) ? dictionnaryPosition[n] : 0).Sum();
        }

    }
}
