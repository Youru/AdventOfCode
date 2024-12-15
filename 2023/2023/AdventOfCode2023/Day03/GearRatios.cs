using PartNumberIndex = (string PartNumber, int FinalIndex);
namespace AdventOfCode2023.Day03
{
    public class GearRatios
    {
        public List<EngineElement> ConstructEngine(List<string> engineDefinition)
        {
            List<EngineElement> engine = new();
            int index = 0;
            foreach (string engineDefinitionItem in engineDefinition)
            {
                List<EngineElement> engineElementByLine = GetEngineLine(engineDefinitionItem, index);
                index++;
                engine.AddRange(engineElementByLine);
            }
            return engine;
        }

        public List<int> GetEngineParNumberNearSymbol(List<EngineElement> engine)
        {
            List<int> partNumberNearSymbol = new();
            var symbols = engine.Where(e => e.EngineType == EngineType.Symbol).ToList();
            var partNumbers = engine.Where(e => e.EngineType == EngineType.PartNumber).ToList();

            foreach (var partNumber in partNumbers)
            {
                Position initialPosition = partNumber.InitialPosition;
                List<int> allowedIndex = [initialPosition.X - 1, initialPosition.X, initialPosition.X + 1];
                var engineSymbolElements = symbols.Where(e => allowedIndex.Contains(e.InitialPosition.X)).ToList();
                if (engineSymbolElements.Any(esl => IsNearPartNumber(esl, partNumber)))
                    partNumberNearSymbol.Add(int.Parse(partNumber.Value));
            }

            return partNumberNearSymbol;
        }
        public int GetSumPoweredOfPartNumberNearGear(List<EngineElement> engine)
        {
            List<List<int>> partNumbersNearGearList = new();
            var gears = engine.Where(e => e.EngineType == EngineType.Gear).ToList();
            var partNumbers = engine.Where(e => e.EngineType == EngineType.PartNumber).ToList();

            foreach (var gear in gears)
            {
                Position initialPosition = gear.InitialPosition;
                List<int> allowedIndex = [initialPosition.X - 1, initialPosition.X, initialPosition.X + 1];
                var enginePartNumberElements = partNumbers.Where(e => allowedIndex.Contains(e.InitialPosition.X)).ToList();
                var partNumbersNearGear = enginePartNumberElements.Where(epne => IsNearPartNumber(gear, epne)).Select(epne => int.Parse(epne.Value)).ToList();
                partNumbersNearGearList.Add(partNumbersNearGear);
            }


            var partNumbersToPoweredList = partNumbersNearGearList.Where(x => x.Count == 2);
            var sum = 0;
            foreach (var partNumberToPowered in partNumbersToPoweredList)
            {
                sum += partNumberToPowered[0] * partNumberToPowered[1];
            }

            return sum;
        }

        private bool IsNearPartNumber(EngineElement esl, EngineElement partNumber)
        {
            int initialY = partNumber.InitialPosition.Y;
            int finalY = partNumber.FinalPosition.Y;
            if (initialY - 1 <= esl.InitialPosition.Y && esl.InitialPosition.Y <= finalY + 1)
                return true;
            return false;
        }
        private List<EngineElement> GetEngineLine(string engineDefinitionItem, int index)
        {
            List<EngineElement> engineElements = new();
            for (int i = 0; i < engineDefinitionItem.Length; i++)
            {
                var element = engineDefinitionItem[i];
                if (element == '.')
                    engineElements.Add(new() { EngineType = EngineType.Period, Value = ".", InitialPosition = new(index, i), FinalPosition = new(index, i) });
                else if (element == '*')
                    engineElements.Add(new() { EngineType = EngineType.Gear, Value = "*", InitialPosition = new(index, i), FinalPosition = new(index, i) });
                else if (IsNumericValue(element))
                {
                    PartNumberIndex partNumberIndex = GetPartNumberIndex(engineDefinitionItem, i);
                    engineElements.Add(new() { EngineType = EngineType.PartNumber, Value = partNumberIndex.PartNumber, InitialPosition = new(index, i), FinalPosition = new(index, partNumberIndex.FinalIndex) });
                    i = partNumberIndex.FinalIndex;
                }
                else
                    engineElements.Add(new() { EngineType = EngineType.Symbol, Value = engineDefinitionItem.Substring(i, 1), InitialPosition = new(index, i), FinalPosition = new(index, i) });
            }

            return engineElements;
        }

        private PartNumberIndex GetPartNumberIndex(string engineDefinitionItem, int i)
        {
            string partNumber = engineDefinitionItem.Substring(i, 1);
            int lastIndex = i;
            while (i < engineDefinitionItem.Length - 1)
            {
                i++;
                if (!IsNumericValue(engineDefinitionItem[i]))
                    break;
                partNumber += engineDefinitionItem.Substring(i, 1);
                lastIndex++;
            }
            return new PartNumberIndex(partNumber, lastIndex);
        }

        private bool IsNumericValue(char element)
         => ((int)char.GetNumericValue(element)) != -1;
    }
}
