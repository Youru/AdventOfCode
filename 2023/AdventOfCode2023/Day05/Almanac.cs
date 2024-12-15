
using System.ComponentModel.DataAnnotations;

namespace AdventOfCode2023.Day05
{
    public partial class Almanac
    {
        public long[] Seeds { get; set; }
        public Dictionary<string, List<ConfigurationMap>> Maps { get; set; }
        public Dictionary<string, string> SourceToDestination { get; set; }

        public long FindSeedLocation(long seed)
        {
            return FindLocation("seed", seed);
        }

        private long FindLocation(string source, long currentLocation)
        {
            if (source is null) return currentLocation;
            var destinationLocation = SourceToDestination.TryGetValue(source, out var destination) ? destination : null;
            var nextLocation = GetNextLocation(source, currentLocation);
            return FindLocation(destinationLocation, nextLocation);
        }

        public long GetNextLocation(string key, long currentLocation)
        {
            if (!Maps.TryGetValue(key, out List<ConfigurationMap> configurations)) return currentLocation;

            var mapping = configurations.FirstOrDefault(c => c.SourceRangeStart <= currentLocation && currentLocation <= c.SourceRangeStart + c.Range);

            if (mapping is null) return currentLocation;
            var newRange = currentLocation - mapping.SourceRangeStart;
            return mapping.DestinationRangeStart + newRange;
        }

        public List<long> GetSeedFinalLocations()
        {
            List<long> locations = new();
            foreach (var seed in Seeds)
            {
                var location = FindSeedLocation(seed);
                locations.Add(location);
            }
            return locations;
        }
    }
    public record ConfigurationMap(long DestinationRangeStart, long SourceRangeStart, long Range)
    {
        public Dictionary<long, long> Mapping()
        {
            Dictionary<long, long> mapping = new();
            for (int i = 0; i < Range; i++)
            {
                mapping.Add(SourceRangeStart + i, DestinationRangeStart + i);
            }
            return mapping;
        }
    }
}
