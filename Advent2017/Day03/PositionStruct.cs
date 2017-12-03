using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2017.Day03
{

    public struct PositionStruct
    {
        public PositionStruct(int x, int y) { X = x; Y = y; }
        public int X { get; }
        public int Y { get; }
        public PositionStruct[] Neighbours
        {
            get
            {
                return new PositionStruct[]
                {
                    new PositionStruct(X-1,Y-1),new PositionStruct(X,Y-1), new PositionStruct(X+1,Y-1),
                    new PositionStruct(X-1,Y),                             new PositionStruct(X+1,Y),
                    new PositionStruct(X-1,Y+1),new PositionStruct(X,Y+1), new PositionStruct(X+1,Y+1),
                };
            }
        }
    }
}
