using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day05
{
    public class Fertilizer
    {
        public Almanac ConstructAlmanac(string almanacRaw)
        {
            var sections = almanacRaw.Split(new string[] { Environment.NewLine + Environment.NewLine },
                               StringSplitOptions.RemoveEmptyEntries);
            long[] seeds = GetNumbersFromString(sections[0]);
            Dictionary<string, List<ConfigurationMap>> maps = new();
            Dictionary<string, string> sourceToDestination = new();

            foreach (var section in sections.Skip(1))
            {
                var map = ParseToSourceToDestination(section);
                maps.Add(map.source, map.configurations.OrderBy(c => c.SourceRangeStart).ToList());
                sourceToDestination.Add(map.source, map.destination);
            }

            return new() { Seeds = seeds, Maps = maps, SourceToDestination = sourceToDestination };
        }

        private (string source, string destination, List<ConfigurationMap> configurations) ParseToSourceToDestination(string section)
        {
            List<ConfigurationMap> configurations = new();
            var mapConfig = section.Split(Environment.NewLine);
            var header = mapConfig[0].Replace(" map:", "").Split("-to-");

            foreach (var config in mapConfig.Skip(1))
            {
                var numbers = GetNumbersFromString(config);
                configurations.Add(new(numbers[0], numbers[1], numbers[2]));
            }

            return (header[0], header[1], configurations);
        }

        private long[] GetNumbersFromString(string line)
        {
            string pattern = @"\d+";
            var matches = Regex.Matches(line, pattern);
            return matches.Select(m => long.Parse(m.Value)).ToArray();

        }
    }
}
