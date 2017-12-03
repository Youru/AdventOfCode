using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2017.Day3
{
    public class Direction
    {
        public DirectionEnum ChooseNextDirection(DirectionEnum direction, int lastX, int lastY, Dictionary<PositionStruct, int> dictionnaryPosition)
        {
            switch (direction)
            {
                case DirectionEnum.Right:
                    return GetDirectionForRight(dictionnaryPosition, lastX, lastY);
                case DirectionEnum.Top:
                    return GetDirectionForTop(dictionnaryPosition, lastX, lastY);
                case DirectionEnum.Left:
                    return GetDirectionForLeft(dictionnaryPosition, lastX, lastY);
                case DirectionEnum.Bottom:
                    return GetDirectionForBottom(dictionnaryPosition, lastX, lastY);
                default:
                    throw new Exception("Direction not known");
            }
        }

        private DirectionEnum GetDirectionForRight(Dictionary<PositionStruct, int> dictionnaryPosition, int lastX, int lastY)
        {
            return !dictionnaryPosition.ContainsKey(new PositionStruct(lastX, --lastY)) ? DirectionEnum.Top : DirectionEnum.Right;
        }

        private DirectionEnum GetDirectionForTop(Dictionary<PositionStruct, int> dictionnaryPosition, int lastX, int lastY)
        {
            return !dictionnaryPosition.ContainsKey(new PositionStruct(--lastX, lastY)) ? DirectionEnum.Left : DirectionEnum.Top;
        }

        private DirectionEnum GetDirectionForLeft(Dictionary<PositionStruct, int> dictionnaryPosition, int lastX, int lastY)
        {
            return !dictionnaryPosition.ContainsKey(new PositionStruct(lastX, ++lastY)) ? DirectionEnum.Bottom : DirectionEnum.Left;
        }

        private DirectionEnum GetDirectionForBottom(Dictionary<PositionStruct, int> dictionnaryPosition, int lastX, int lastY)
        {
            return !dictionnaryPosition.ContainsKey(new PositionStruct(++lastX, lastY)) ? DirectionEnum.Right : DirectionEnum.Bottom;
        }
    }
}
