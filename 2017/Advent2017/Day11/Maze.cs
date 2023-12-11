using System.Collections.Generic;

namespace Advent2017.Day11
{
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
}
