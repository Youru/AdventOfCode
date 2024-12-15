


namespace AdventOfCode2024.Day06
{
    public class Resolve
    {
        public static char[,] map;
        public int GetMaxObstructionPath(List<string> list)
        {
            int numberObstructionPath = 0;
            var guardPosition = InitConfiguration(list);

            var guardPositions = GetAllPositionsGuard(guardPosition);
            //List<Task<int>> tasks = new();
            foreach (var position in guardPositions.Select(p => p.Position).Distinct())
            {
                numberObstructionPath += CalculObstructionPath(guardPosition, position);
            }
            //foreach (var position in guardPositions[1..^1])
            //{
            //    tasks.Add(Task.Run(() =>
            //    numberObstructionPath += CalculObstructionPath(position)));
            //}

            //Task.WaitAll(tasks.ToArray());
            //numberObstructionPath = tasks.Select(t => t.Result).Sum();
            return numberObstructionPath;
        }

        public int GetMaxPathStep(List<string> list)
        {
            var guardPosition = InitConfiguration(list);

            var positions = GetAllPositionsGuard(guardPosition);

            return positions.Select(p => p.Position).Distinct().Count();
        }

        private static GuardPosition InitConfiguration(List<string> list)
        {
            GuardPosition guardPosition;

            guardPosition = new(new(0, 0), 0);
            map = new char[list.Count, list.First().Count()];
            foreach (var item in list.Select((value, i) => new { i, value }))
                for (int i = 0; i < item.value.Length; i++)
                {
                    map[item.i, i] = item.value[i];
                    if (item.value[i] is '^')
                        guardPosition = new(new(item.i, i), Direction.Up);
                }

            return guardPosition;
        }
        private int CalculObstructionPath(GuardPosition guardPosition, Position obstructionPosition)
        {
            //var obstructionPosition = GetNumberMaxPathToMove(guardPosition).First();
            //if (map[obstructionPosition.x, obstructionPosition.y] is '#') return 0;
            //var guardPosition2 = guardPosition with { Direction = guardPosition.Direction.Turn() };
            map[obstructionPosition.x, obstructionPosition.y] = '#';
            var sizeMax = map.GetLength(0) * map.GetLength(1);
            var isLooped = IsLoopedPosition2(guardPosition, sizeMax);

            map[obstructionPosition.x, obstructionPosition.y] = '.';
            return isLooped ? 1 : 0;
        }

        private bool IsLoopedPosition(GuardPosition guardPosition, Position obstructionPosition)
        {
            List<GuardPosition> pastPositions = [];
            Dictionary<Position, int> positionCount = new();
            GuardPosition guardPosition2 = guardPosition;
            bool hasLeft = true;
            bool isLoop = false;
            do
            {
                var positions = GetNumberMaxPathToMove(guardPosition2);
                hasLeft = positions.Count == 0;
                for (int i = 0; i < positions.Count; i++)
                {
                    Position position = new(positions[i].x, positions[i].y);
                    var positionValue = positionCount.TryGetValue(position, out var count) ? 0 : count;
                    if (map[positions[i].x, positions[i].y] is '#' || obstructionPosition == new Position(positions[i].x, positions[i].y))
                    {
                        var x = i is 0 ? guardPosition2.Position.x : positions[i - 1].x;
                        var y = i is 0 ? guardPosition2.Position.y : positions[i - 1].y;
                        position = new(x, y);
                        guardPosition2 = new(position, guardPosition2.Direction.Turn());
                        hasLeft = false;
                        break;
                    }
                    hasLeft = true;
                    positionCount[position] = ++count;
                    pastPositions.Add(new(position, guardPosition2.Direction));

                    if (count is 4)
                    {
                        if (guardPosition.Position != obstructionPosition)
                            isLoop = true;
                        break;
                    }
                }
            } while (hasLeft is false && isLoop is false);
            return isLoop;
        }
        private bool IsLoopedPosition2(GuardPosition guardPosition, int maxSize)
        {
            List<GuardPosition> pastPositions = [];
            Dictionary<Position, int> positionCount = new();
            GuardPosition guardPosition2 = guardPosition;
            bool hasLeft = true;
            bool isLoop = false;
            int count = 0;
            do
            {
                var positions = GetNumberMaxPathToMove(guardPosition2);
                hasLeft = positions.Count == 0;
                for (int i = 0; i < positions.Count; i++)
                {
                    Position position = new(positions[i].x, positions[i].y);
                    if (map[positions[i].x, positions[i].y] is '#')
                    {
                        var x = i is 0 ? guardPosition2.Position.x : positions[i - 1].x;
                        var y = i is 0 ? guardPosition2.Position.y : positions[i - 1].y;
                        position = new(x, y);
                        guardPosition2 = new(position, guardPosition2.Direction.Turn());
                        hasLeft = false;
                        break;
                    }
                    hasLeft = true;
                    count++;
                    if (maxSize < count)
                    {
                        isLoop = true;
                        break;
                    }
                }
            } while (hasLeft is false && isLoop is false);
            return isLoop;
        }

        private bool isLoopCanBeCreated(List<GuardPosition> pastGuardPositions, GuardPosition guardPosition)
        {
            guardPosition = guardPosition with { Direction = guardPosition.Direction.Turn() };
            var positions = GetNumberMaxPathToMove(guardPosition);
            return positions.Any(p => pastGuardPositions.Contains(new(p, guardPosition.Direction)));
        }

        private List<GuardPosition> GetAllPositionsGuard(GuardPosition guardPosition)
        {
            List<GuardPosition> pastPositions = [];
            bool hasLeft = true;
            do
            {
                var positions = GetNumberMaxPathToMove(guardPosition);
                for (int i = 0; i < positions.Count; i++)
                {
                    Position position = new(positions[i].x, positions[i].y);
                    if (map[positions[i].x, positions[i].y] is '#')
                    {
                        var x = i is 0 ? guardPosition.Position.x : positions[i - 1].x;
                        var y = i is 0 ? guardPosition.Position.y : positions[i - 1].y;
                        position = new(x, y);
                        guardPosition = new(position, guardPosition.Direction.Turn());
                        hasLeft = false;
                        break;
                    }
                    hasLeft = true;
                    pastPositions.Add(new(position, guardPosition.Direction));
                }
            } while (hasLeft is false);
            return pastPositions;
        }

        private List<Position> GetNumberMaxPathToMove(GuardPosition guardPosition)
        {
            List<Position> positions = guardPosition.Direction switch
            {
                Direction.Up => Enumerable.Range(1, guardPosition.Position.x).Select(r => new Position(guardPosition.Position.x - r, guardPosition.Position.y)).ToList(),
                Direction.Down => Enumerable.Range(guardPosition.Position.x, map.GetLength(0) - 1 - guardPosition.Position.x).Select(r => new Position(r + 1, guardPosition.Position.y)).ToList(),
                Direction.Left => Enumerable.Range(1, guardPosition.Position.y).Select(r => new Position(guardPosition.Position.x, guardPosition.Position.y - r)).ToList(),
                Direction.Right => Enumerable.Range(guardPosition.Position.y, map.GetLength(1) - 1 - guardPosition.Position.y).Select(r => new Position(guardPosition.Position.x, r + 1)).ToList(),
                _ => [new(0, 0)]
            };
            return positions;
        }
    }
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public record Position(int x, int y);
    public record GuardPosition(Position Position, Direction Direction);

    public static class Helper
    {
        public static Direction Turn(this Direction direction) => direction switch
        {
            Direction.Up => Direction.Right,
            Direction.Right => Direction.Down,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
        };
    }
}
