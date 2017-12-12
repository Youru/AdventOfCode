using Advent2017.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Advent2017.Day11
{
    public class Advent
    {
        private Maze maze;
        public int FurthestPosition { get; set; } = 0;

        public Advent() { maze = new Maze(); }

        public List<string> GetHexes(string inputs) => inputs.Split(',').ToList();

        public int GetNumberStepToEscapeTheMaze(List<string> hexes)
        {
            var position = maze.Hexes["c"];

            hexes.ForEach(h =>
            {
                position += maze.Hexes[h];
                FurthestPosition = Math.Max(position.NumberStepToEscape(), FurthestPosition);
            });

            return position.NumberStepToEscape();
        }
    }

    public class Maze
    {
        public Dictionary<string, Hexe> Hexes
        {
            get
            {
                return new Dictionary<string, Hexe>()
                {
                    ["nw"] = new Hexe(-1, 1, 0),
                    ["n"] = new Hexe(0, 1, -1),
                    ["ne"] = new Hexe(1, 0, -1),
                    ["c"] = new Hexe(0, 0, 0),
                    ["sw"] = new Hexe(-1, 0, 1),
                    ["s"] = new Hexe(0, -1, 1),
                    ["se"] = new Hexe(1, -1, 0),
                };
            }
        }
    }

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
