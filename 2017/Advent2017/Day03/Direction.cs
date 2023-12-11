using System;
using System.Collections.Generic;

namespace Advent2017.Day03
{
    public class Direction
    {
        public DirectionEnum ChooseNextDirection(DirectionEnum direction, int lastX, int lastY, Dictionary<string, int> dictionnaryPosition)
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

        private DirectionEnum GetDirectionForRight(Dictionary<string, int> dictionnaryPosition, int lastX, int lastY)
            => !dictionnaryPosition.ContainsKey($"{lastX}:{--lastY}") ? DirectionEnum.Top : DirectionEnum.Right;


        private DirectionEnum GetDirectionForTop(Dictionary<string, int> dictionnaryPosition, int lastX, int lastY)
            => !dictionnaryPosition.ContainsKey($"{--lastX}:{lastY}") ? DirectionEnum.Left : DirectionEnum.Top;


        private DirectionEnum GetDirectionForLeft(Dictionary<string, int> dictionnaryPosition, int lastX, int lastY)
            => !dictionnaryPosition.ContainsKey($"{lastX}:{++lastY}") ? DirectionEnum.Bottom : DirectionEnum.Left;

        private DirectionEnum GetDirectionForBottom(Dictionary<string, int> dictionnaryPosition, int lastX, int lastY)
            => !dictionnaryPosition.ContainsKey($"{++lastX}:{lastY}") ? DirectionEnum.Right : DirectionEnum.Bottom;
    }
}
