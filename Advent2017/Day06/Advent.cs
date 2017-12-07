using Advent2017.Extension;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Advent2017.Day06
{
    public class Advent
    {
        public int GetNumberRedistributionCycle(string maze)
        {
            var infiniteLoopDetected = false;
            var historyBlocks = new Dictionary<string, int>();
            var blocks = GetBlocks(maze);
            var loop = 0;

            while (infiniteLoopDetected == false)
            {
                var higherBlock = blocks.Max();
                var indexBlock = blocks.FindIndex(b => b == higherBlock);
                blocks[indexBlock] = 0;
                for (var i = 1; i <= higherBlock; i++)
                {
                    blocks[(indexBlock + i) % blocks.Count]++;
                }

                if (historyBlocks.ContainsKey(string.Join(",", blocks))) { 
                    infiniteLoopDetected = true;
                }
                else
                {
                    historyBlocks.Add(string.Join(",", blocks), loop);
                }
                loop++;
            }

            return loop;

        }

        public int GetCycleNumberBetweenDuplicate(string maze)
        {
            var infiniteLoopDetected = false;
            var historyBlocks = new Dictionary<string, int>();
            var blocks = GetBlocks(maze);
            var loop = 0;
            var numberCycle = 0;

            while (infiniteLoopDetected == false)
            {
                var higherBlock = blocks.Max();
                var indexBlock = blocks.FindIndex(b => b == higherBlock);
                blocks[indexBlock] = 0;
                for (var i = 1; i <= higherBlock; i++)
                {
                    blocks[(indexBlock + i) % blocks.Count]++;
                }

                if (historyBlocks.ContainsKey(string.Join(",", blocks)))
                {
                    infiniteLoopDetected = true;
                    numberCycle = loop - historyBlocks[string.Join(",", blocks)];
                }
                else
                {
                    historyBlocks.Add(string.Join(",", blocks), loop);
                }
                loop++;
            }

            return numberCycle;

        }

        private List<int> GetBlocks(string input) => (input.Split(' ').ToList().Select(x => int.Parse(x))).ToList();
    }
}
