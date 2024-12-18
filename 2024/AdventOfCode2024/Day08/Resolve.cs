using AdventOfCode2024.Shared;

namespace AdventOfCode2024.Day08
{
    public class Resolve
    {
        public static char[,] _map;
        public long GetNumberOfUniqueLocalisation(List<string> list)
        {
            int count = 0;
            _map = ArrayHelper.ConvertToArray(list);
            Dictionary<char, List<Position>> positions = GetPositionByAntenna();
            Dictionary<char, List<Position>> positionAntinodes = GetAntinodesPosition(positions);

            foreach (var position in positionAntinodes.SelectMany(p => p.Value))
            {
                if (_map[position.x, position.y] is not '#')
                {
                    _map[position.x, position.y] = '#';
                    count++;
                }
            }
            var display = ArrayHelper.DisplayArray(_map);


            return count;
        }
        public long GetNumberOfUniqueLocalisationWithResonantHarmonic(List<string> list)
        {
            int count = 0;
            _map = ArrayHelper.ConvertToArray(list);
            Dictionary<char, List<Position>> positions = GetPositionByAntenna();
            Dictionary<char, List<Position>> positionAntinodes = GetAntinodesPositionWithResonantHarmonic(positions);

            int countanti = 0;
            foreach (var position in positionAntinodes.SelectMany(p => p.Value))
            {
                var antenna = _map[position.x, position.y];
                if (antenna is not '#')
                {
                    if (antenna is '.')
                        _map[position.x, position.y] = '#';
                    else
                        countanti++;
                    count++;
                }
            }
            var display = ArrayHelper.DisplayArray(_map);

            count += positions.SelectMany(c => c.Value).Count()- countanti;
            return count;
        }

        private Dictionary<char, List<Position>> GetPositionByAntenna()
        {
            Dictionary<char, List<Position>> positions = [];
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                string line = string.Empty;
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    if (_map[i, j] is not '.')
                        SetValue(_map[i, j], new(i, j));
                }
            }
            return positions;

            void SetValue(char antenna, Position position)
            {
                var values = positions.TryGetValue(antenna, out var antennaPositions) ? antennaPositions : [];
                values.Add(position);
                positions[antenna] = values;
            }
        }

        private Dictionary<char, List<Position>> GetAntinodesPosition(Dictionary<char, List<Position>> antennaPositions)
        {
            Dictionary<char, List<Position>> antinodePositions = [];
            foreach (var antennaPosition in antennaPositions)
            {
                antinodePositions[antennaPosition.Key] = [];
                var positions = antennaPosition.Value;
                for (int i = 0; i < positions.Count; i++)
                {
                    var nextPosition = positions[(i + 1)..];
                    for (int j = 0; j < nextPosition.Count; j++)
                    {
                        var distanceX = Math.Abs(positions[i].x - nextPosition[j].x);
                        var distanceY = positions[i].y - nextPosition[j].y;
                        Position antinode1 = new(positions[i].x - distanceX, positions[i].y + distanceY);
                        Position antinode2 = new(nextPosition[j].x + distanceX, nextPosition[j].y + distanceY * -1);
                        if (IsInMap(antinode1)) antinodePositions[antennaPosition.Key].Add(antinode1);
                        if (IsInMap(antinode2)) antinodePositions[antennaPosition.Key].Add(antinode2);
                    }

                }
            }
            return antinodePositions;

            bool IsInMap(Position position) =>
                position.x >= 0 && position.x <= _map.GetLength(0) - 1 &&
                position.y >= 0 && position.y <= _map.GetLength(1) - 1;
        }
        private Dictionary<char, List<Position>> GetAntinodesPositionWithResonantHarmonic(Dictionary<char, List<Position>> antennaPositions)
        {
            Dictionary<char, List<Position>> antinodePositions = [];
            foreach (var antennaPosition in antennaPositions)
            {
                antinodePositions[antennaPosition.Key] = [];
                var positions = antennaPosition.Value;
                for (int i = 0; i < positions.Count; i++)
                {
                    var nextPosition = positions[(i + 1)..];
                    for (int j = 0; j < nextPosition.Count; j++)
                    {
                        var distanceX = Math.Abs(positions[i].x - nextPosition[j].x);
                        var distanceY = positions[i].y - nextPosition[j].y;
                        Position ecart1 = new(distanceX * -1, distanceY);
                        Position ecart2 = new(distanceX * 1, distanceY * -1);
                        Position firstElem = new Position(positions[i].x, positions[i].y);
                        Position secondElem = new Position(nextPosition[j].x, nextPosition[j].y);

                        Position antinode1 = firstElem.AddPosition(ecart1);
                        Position antinode2 = secondElem.AddPosition(ecart2);
                        do
                        {
                            if (IsInMap(antinode1)) antinodePositions[antennaPosition.Key].Add(antinode1);
                            if (IsInMap(antinode2)) antinodePositions[antennaPosition.Key].Add(antinode2);

                            antinode1 = antinode1.AddPosition(ecart1);
                            antinode2 = antinode2.AddPosition(ecart2);
                        } while (IsInMap(antinode1) || IsInMap(antinode2));
                    }

                }
            }
            return antinodePositions;

            bool IsInMap(Position position) =>
                position.x >= 0 && position.x <= _map.GetLength(0) - 1 &&
                position.y >= 0 && position.y <= _map.GetLength(1) - 1;
        }
    }
    public record Position(int x, int y);

    public static class PositionHelper
    {
        public static Position AddPosition(this Position currentPosition, Position addedPosition)
        {
            return currentPosition with { x = currentPosition.x + addedPosition.x, y = currentPosition.y + addedPosition.y };
        }
    }

}
