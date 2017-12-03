using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2017.Day03
{
    public class Position
    {

        private Direction direction;
        public Position() { direction = new Direction(); }

        public PositionStruct GoToNextPosition(Dictionary<string, int> dictionnaryPosition, PositionStruct currentPosition)
        {
            var currentDirection = dictionnaryPosition.Count > 1 ?
                                    direction.ChooseNextDirection(currentPosition.Direction, currentPosition.X, currentPosition.Y, dictionnaryPosition)
                                    : DirectionEnum.Right;
            return CalculPosition(currentPosition.X, currentPosition.Y, currentDirection);
        }

        private PositionStruct CalculPosition(int x, int y, DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.Right:
                    return new PositionStruct(++x, y, direction);
                case DirectionEnum.Top:
                    return new PositionStruct(x, --y, direction);
                case DirectionEnum.Left:
                    return new PositionStruct(--x, y, direction);
                case DirectionEnum.Bottom:
                    return new PositionStruct(x, ++y, direction);
                default:
                    throw new Exception("Direction not known");
            }
        }
    }
}
