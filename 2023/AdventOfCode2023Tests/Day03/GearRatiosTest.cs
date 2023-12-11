using AdventOfCode2023.Day03;
using AdventOfCode2023Tests.Common;
using FluentAssertions;

namespace AdventOfCode2023Tests.Day03
{
    public class GearRatiosTest
    {
        private readonly GearRatios _gearRatios;
        private readonly string _basePath = "Day03/Input";

        public GearRatiosTest()
        {
            _gearRatios = new GearRatios();
        }

        [Fact]
        public void Should_Retrieve_All_EngineElement()
        {
            string map = """
                467.+114..
                .664.598..
                """;
            List<EngineElement> engineElementsExpected = new()
            {
                new EngineElement{EngineType=EngineType.PartNumber,Value="467",InitialPosition=new (0,0),FinalPosition=new (0,2)},
                new EngineElement{EngineType=EngineType.Period,Value=".",InitialPosition=new (0,3),FinalPosition=new (0,3)},
                new EngineElement{EngineType=EngineType.Symbol,Value="+",InitialPosition=new (0,4),FinalPosition=new (0,4)},
                new EngineElement{EngineType=EngineType.PartNumber,Value="114",InitialPosition=new (0,5),FinalPosition=new (0,7)},
                new EngineElement{EngineType=EngineType.Period,Value=".",InitialPosition=new (0,8),FinalPosition=new (0,8)},
                new EngineElement{EngineType=EngineType.Period,Value=".",InitialPosition=new (0,9),FinalPosition=new (0,9)},
                new EngineElement{EngineType=EngineType.Period,Value=".",InitialPosition=new (1,0),FinalPosition=new (1,0)},
                new EngineElement{EngineType=EngineType.PartNumber,Value="664",InitialPosition=new (1,1),FinalPosition=new (1,3)},
                new EngineElement{EngineType=EngineType.Period,Value=".",InitialPosition=new (1,4),FinalPosition=new (1,4)},
                new EngineElement{EngineType=EngineType.PartNumber,Value="598",InitialPosition=new (1,5),FinalPosition=new (1,7)},
                new EngineElement{EngineType=EngineType.Period,Value=".",InitialPosition=new (1,8),FinalPosition=new (1,8)},
                new EngineElement{EngineType=EngineType.Period,Value=".",InitialPosition=new (1,9),FinalPosition=new (1,9)},
            };

            var engine = _gearRatios.ConstructEngine(map.Split(Environment.NewLine).ToList());

            engine.Should().BeEquivalentTo(engineElementsExpected);
        }

        [Fact]
        public void Should_Retrieve_All_PartNumber_Near_Symbol()
        {
            string map = """
                467.+114..
                .664.598..
                """;
            List<int> expectedPartNumbers = [114, 664, 598];

            var engine = _gearRatios.ConstructEngine(map.Split(Environment.NewLine).ToList());
            List<int> partNumbers = _gearRatios.GetEngineParNumberNearSymbol(engine);

            partNumbers.Should().BeEquivalentTo(expectedPartNumbers);
        }
        [Fact]
        public void Should_Retrieve_All_PartNumber_Near_Gear_And_Sum_Only_Ones_To_Powered()
        {
            string map = """
                467..114..
                ...*......
                ..35..633.
                ......#...
                617*......
                .....+.58.
                ..592.....
                ......755.
                ...$.*....
                .664.598..
                """;

            var engine = _gearRatios.ConstructEngine(map.Split(Environment.NewLine).ToList());
            int sumPowered = _gearRatios.GetSumPoweredOfPartNumberNearGear(engine);

            sumPowered.Should().Be(467835);
        }

        [Fact]
        public void Should_Sum_PartNumber_Near_Symbol()
        {
            List<string> engineDefinition = FileHelper.GetContentByLine(_basePath, "Input1.txt");

            var engine = _gearRatios.ConstructEngine(engineDefinition);
            List<int> partNumbers = _gearRatios.GetEngineParNumberNearSymbol(engine);
            int partNumberSummed = partNumbers.Sum();
            partNumberSummed.Should().Be(556057);
        }
        [Fact]
        public void Should_Sum_PartNumber_Near_Symbol__For_Input()
        {
            List<string> engineDefinition = FileHelper.GetContentByLine(_basePath, "Input2.txt");

            var engine = _gearRatios.ConstructEngine(engineDefinition);
            int sumPowered = _gearRatios.GetSumPoweredOfPartNumberNearGear(engine);
            sumPowered.Should().Be(82824352);
        }
    }
}
