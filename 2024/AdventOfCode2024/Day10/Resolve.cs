using AdventOfCode2024.Shared;

namespace AdventOfCode2024.Day10
{
    public class Resolve
    {
        private char[,] _map;

        private readonly List<PositionMap> NextPositions = [
            new (-1,0),
            new (0,-1),
            new (1,0),
            new (0,1),
            ];
        public long GetTrailheadScore(List<string> list, bool isDistinct = true)
        {
            _map = ArrayHelper.ConvertToArray(list);
            List<PositionMap> mapPositions = [];
            List<PositionMap> endPosition = [];

            for (int i = 0; i < _map.GetLength(0); i++)
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] is '0')
                        mapPositions.Add(new PositionMap(i, j));
                }

            foreach (var position in mapPositions)
            {
                endPosition.AddRange(GetEndPosition(position, isDistinct));
            };
            int numberOfUniqueEnd = endPosition.Count();
            return numberOfUniqueEnd;
        }

        private IEnumerable<PositionMap> GetEndPosition(PositionMap position, bool isDistinct = true)
        {
            List<PositionMap> endPositions = [];
            Queue<PositionMap> trailPath = [];
            trailPath.Enqueue(position);
            do
            {
                var path = trailPath.Dequeue();
                var value = _map[path.X, path.Y];
                var nextValue = GetNext(value);
                foreach (var nextPath in NextPositions)
                {
                    var x = path.X + nextPath.X;
                    var y = path.Y + nextPath.Y;
                    if (x < 0 || y < 0 || x >= _map.GetLength(0) || y >= _map.GetLength(1))
                        continue;
                    var nextPathValue = _map[x, y];

                    if (nextPathValue == nextValue && nextPathValue is '9')
                    {
                        endPositions.Add(new(x, y));
                        continue;
                    }
                    if (nextPathValue == nextValue)
                        trailPath.Enqueue(new(x, y));

                }

            } while (trailPath.Count > 0);
            if (isDistinct)
                return endPositions.Distinct();

            return endPositions;
        }

        public char GetNext(char c) => c switch
        {
            '0' => '1',
            '1' => '2',
            '2' => '3',
            '3' => '4',
            '4' => '5',
            '5' => '6',
            '6' => '7',
            '7' => '8',
            '8' => '9',
            '9' => '.',
            _ => '.'
        };

    }
}