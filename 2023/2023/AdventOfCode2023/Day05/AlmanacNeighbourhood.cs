
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day05
{
    public partial class Almanac
    {


        public long GetPairedSeedFinalLocations(string input)
        {
            List<(long seeds, long length)> seedRanges = new();
            for (int i = 0; i < Seeds.Count(); i += 2)
            {
                seedRanges.Add((Seeds[i], Seeds[i + 1]));
            }
            long lowestValue = long.MaxValue;

            foreach (var (seed, length) in seedRanges)
            {
                for (long i = seed; i < seed + length; i++)
                {
                    var res = GetSeedPosition(i);
                    if (res < lowestValue)
                        lowestValue = res;
                }
            }

            return lowestValue;
        }
        long GetSeedPosition(long seed)
        {
            long curPos = seed;
            foreach (var map in Maps.Values)
            {
                foreach (var (destRange, sourceRangeStart, length) in map)
                {
                    if (sourceRangeStart <= curPos && curPos < sourceRangeStart + length)
                    {
                        curPos = destRange + (curPos - sourceRangeStart);
                        break;
                    }

                }
            }

            return curPos;
        }

    }
}
