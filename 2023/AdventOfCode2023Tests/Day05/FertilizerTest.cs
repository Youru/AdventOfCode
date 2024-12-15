using AdventOfCode2023.Day05;
using AdventOfCode2023Tests.Common;
using FluentAssertions;

namespace AdventOfCode2023Tests.Day05
{
    public class FertilizerTest
    {
        private readonly Fertilizer _fertilizer;
        private readonly string _basePath = "Day05/Input";


        public FertilizerTest()
        {
            _fertilizer = new Fertilizer();
        }

        [Fact]
        public void Should_Construct_Model()
        {
            var almanacRaw = """
                seeds: 79 14 55 13

                seed-to-soil map:
                50 98 2

                soil-to-fertilizer map:
                0 15 37
                37 52 2
                """;
            Almanac expectedAlmanac = new()
            {
                Seeds = [79, 14, 55, 13],
                Maps = new()
                {
                    ["seed"] = new List<ConfigurationMap>() { new(50, 98, 2) },
                    ["soil"] = new List<ConfigurationMap>() { new(0, 15, 37), new(37, 52, 2) }
                },
                SourceToDestination = new()
                {
                    ["seed"] = "soil",
                    ["soil"] = "fertilizer"
                }
            };

            Almanac almanac = _fertilizer.ConstructAlmanac(almanacRaw);

            almanac.Should().BeEquivalentTo(expectedAlmanac);
        }

        [Fact]
        public void Should_Get_Next_Location_For_Seed_To_Soil()
        {
            var almanacRaw = """
                seeds: 79 14 55 13

                seed-to-soil map:
                50 98 2
                52 50 48

                soil-to-fertilizer map:
                0 15 37
                37 52 2
                39 0 15
                """;

            Almanac almanac = _fertilizer.ConstructAlmanac(almanacRaw);

            var nextLocation = almanac.GetNextLocation("seed", 79);
            nextLocation.Should().Be(81);
        }
        [Theory]
        [InlineData(79, 82)]
        [InlineData(14, 43)]
        [InlineData(55, 86)]
        [InlineData(13, 35)]
        public void Should_Find_Location_For_Seed(int seed, int expectedLocation)
        {
            var almanacRaw = """
                seeds: 79 14 55 13

                seed-to-soil map:
                50 98 2
                52 50 48

                soil-to-fertilizer map:
                0 15 37
                37 52 2
                39 0 15

                fertilizer-to-water map:
                49 53 8
                0 11 42
                42 0 7
                57 7 4

                water-to-light map:
                88 18 7
                18 25 70

                light-to-temperature map:
                45 77 23
                81 45 19
                68 64 13

                temperature-to-humidity map:
                0 69 1
                1 0 69

                humidity-to-location map:
                60 56 37
                56 93 4
                """;

            Almanac almanac = _fertilizer.ConstructAlmanac(almanacRaw);

            long location = almanac.FindSeedLocation(seed);

            location.Should().Be(expectedLocation);
        }
        [Fact]
        public void Should_Find_Minimal_Location_Between_Seed_With_Input()
        {
            string almanacRaw = FileHelper.GetContent(_basePath, "Input1.txt");
            Almanac almanac = _fertilizer.ConstructAlmanac(almanacRaw);
            List<long> locations = almanac.GetSeedFinalLocations();

            var minValue = locations.Min();

            minValue.Should().Be(251346198);
        }
        [Fact]
        public void Should_Find_Minimal_Location_For_Paired_Seed()
        {
            var almanacRaw = """

                seeds: 79 14 55 13

                seed-to-soil map:
                50 98 2
                52 50 48

                soil-to-fertilizer map:
                0 15 37
                37 52 2
                39 0 15

                fertilizer-to-water map:
                49 53 8
                0 11 42
                42 0 7
                57 7 4

                water-to-light map:
                88 18 7
                18 25 70

                light-to-temperature map:
                45 77 23
                81 45 19
                68 64 13

                temperature-to-humidity map:
                0 69 1
                1 0 69

                humidity-to-location map:
                60 56 37
                56 93 4
                """;

            Almanac almanac = _fertilizer.ConstructAlmanac(almanacRaw);

            long locations = almanac.GetPairedSeedFinalLocations(almanacRaw);


            locations.Should().Be(46);
        }
        [Fact]
        public void Should_Find_Minimal_Location_Between_Paired_Seed_With_Input()
        {
            string almanacRaw = FileHelper.GetContent(_basePath, "Input1.txt");
            Almanac almanac = _fertilizer.ConstructAlmanac(almanacRaw);
            long locations = almanac.GetPairedSeedFinalLocations(almanacRaw);


            locations.Should().Be(251346198);
        }
    }
}
