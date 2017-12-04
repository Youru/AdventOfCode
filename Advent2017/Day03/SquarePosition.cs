using System;
using System.Collections.Generic;

namespace Advent2017.Day03
{
    public class SquarePosition
    {

        private Direction direction;
        public SquarePosition() { direction = new Direction(); }

        public Square GetNext(Dictionary<string, int> dictionnaryPosition, Square currentPosition)
        {
            var currentDirection = dictionnaryPosition.Count > 1 ?
                                    direction.ChooseNextDirection(currentPosition.Direction, currentPosition.X, currentPosition.Y, dictionnaryPosition)
                                    : DirectionEnum.Right;
            return GetNew(currentPosition.X, currentPosition.Y, currentDirection);
        }

        private Square GetNew(int x, int y, DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.Right:
                    return new Square(++x, y, direction);
                case DirectionEnum.Top:
                    return new Square(x, --y, direction);
                case DirectionEnum.Left:
                    return new Square(--x, y, direction);
                case DirectionEnum.Bottom:
                    return new Square(x, ++y, direction);
                default:
                    throw new Exception("Direction not known");
            }
        }
    }
}
