using System.Linq;
using System.Collections.Generic;

namespace Advent2017.Day06
{
    public class Advent
    {
        public int GetNumberRedistributionCycle(string maze)
        {
            var historyBlocks = new Dictionary<string, int>();
            var blocks = GetBlocks(maze);

            return  GetNumberLoopTotriggerInfiniteLoop(historyBlocks, blocks);

        }

        public int GetCycleNumberBetweenDuplicate(string maze)
        {
            var historyBlocks = new Dictionary<string, int>();
            var blocks = GetBlocks(maze);

            var loop = GetNumberLoopTotriggerInfiniteLoop(historyBlocks, blocks);
            var numberCycle = loop - historyBlocks[string.Join(",", blocks)];

            return numberCycle;
        }

        private static int GetNumberLoopTotriggerInfiniteLoop(Dictionary<string, int> historyBlocks, List<int> blocks)
        {
            int loop = 0;
            while (!historyBlocks.ContainsKey(string.Join(",", blocks)))
            {
                var higherBlock = blocks.Max();
                var indexBlock = blocks.FindIndex(b => b == higherBlock);

                historyBlocks.Add(string.Join(",", blocks), loop);
                blocks[indexBlock] = 0;

                for (var i = 1; i <= higherBlock; i++)
                {
                    blocks[(indexBlock + i) % blocks.Count]++;
                }

                loop++;
            }

            return loop;
        }

        private List<int> GetBlocks(string input) => (input.Split(' ').ToList().Select(x => int.Parse(x))).ToList();
    }
}
