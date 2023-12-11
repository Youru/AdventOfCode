using System;

namespace Advent2017.Day11
{
    public struct Hexe
    {
        public Hexe(int x, int y, int z) { X = x; Y = y; Z = z; }

        private int X { get; }
        private int Y { get; }
        private int Z { get; }

        public static Hexe operator +(Hexe hexeSource, Hexe HexeToAdd)
            => new Hexe(hexeSource.X + HexeToAdd.X, hexeSource.Y + HexeToAdd.Y, hexeSource.Z + HexeToAdd.Z);

        public int NumberStepToEscape() => (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z)) / 2;
    }
}
