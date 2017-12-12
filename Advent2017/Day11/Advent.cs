using System;
using System.Collections.Generic;
using System.Linq;

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
}
