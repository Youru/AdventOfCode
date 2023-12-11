namespace Advent2017.Day03
{

    public struct Square
    {
        public Square(int x, int y) { X = x; Y = y; Direction = DirectionEnum.Right; }
        public Square(int x, int y, DirectionEnum direction) { X = x; Y = y; Direction = direction; }

        public int X { get; }
        public int Y { get; }
        public string Position => $"{X}:{Y}";
        public DirectionEnum Direction { get; }
        public string[] Neighbours =>
                                new string[]
                                    {
                                        $"{X-1}:{Y-1}",$"{X}:{Y-1}", $"{X+1}:{Y-1}",
                                        $"{X-1}:{Y}",                $"{X+1}:{Y}",
                                        $"{X-1}:{Y+1}",$"{X}:{Y+1}", $"{X+1}:{Y+1}",
                                    };
    }
}
