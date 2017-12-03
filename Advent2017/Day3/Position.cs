using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2017.Day3
{
    public class Position
    {
        public PositionStruct CalculPosition(int x, int y, DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.Right:
                    return new PositionStruct(++x, y);
                case DirectionEnum.Top:
                    return new PositionStruct(x, --y);
                case DirectionEnum.Left:
                    return new PositionStruct(--x, y);
                case DirectionEnum.Bottom:
                    return new PositionStruct(x, ++y);
                default:
                    throw new Exception("Direction not known");
            }
        }
    }
}
