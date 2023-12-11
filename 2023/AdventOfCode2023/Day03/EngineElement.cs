namespace AdventOfCode2023.Day03
{
    public struct EngineElement
    {
        public string Value { get; set; }
        public EngineType EngineType { get; set; }
        public Position InitialPosition { get; set; }
        public Position FinalPosition { get; set; }
    }
    public struct Position(int X, int Y)
    {
        public int X { get; } = X;
        public int Y { get; } = Y;
    }

    public enum EngineType
    {
        Period,
        PartNumber,
        Symbol,
        Gear
    }
}
