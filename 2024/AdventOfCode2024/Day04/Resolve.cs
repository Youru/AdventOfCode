

namespace AdventOfCode2024.Day04
{
    public class Resolve
    {
        public int GetXmasNumber(List<string> list)
        {
            int count = 0;
            char[,] xmasArray = new char[list.Count, list.First().Count()];
            foreach (var item in list.Select((value, i) => new { i, value }))
                for (int i = 0; i < item.value.Length; i++)
                    xmasArray[item.i, i] = item.value[i];

            for (int i = 0; i < xmasArray.GetLength(0); i++)
            {
                for (int j = 0; j < xmasArray.GetLength(1); j++)
                {
                    if (xmasArray[i, j] is not 'X') continue;

                    count += GetCountForAllXmasCases(i, j, xmasArray);
                }
            }

            return count;
        }
        public int GetMasNumber(List<string> list)
        {
            int count = 0;
            char[,] xmasArray = new char[list.Count, list.First().Count()];
            foreach (var item in list.Select((value, i) => new { i, value }))
                for (int i = 0; i < item.value.Length; i++)
                    xmasArray[item.i, i] = item.value[i];

            for (int i = 0; i < xmasArray.GetLength(0); i++)
            {
                for (int j = 0; j < xmasArray.GetLength(1); j++)
                {
                    if (xmasArray[i, j] is not 'A') continue;

                    count += GetCountForAllMasCases(i, j, xmasArray);
                }
            }

            return count;
        }

        private int GetCountForAllXmasCases(int x, int y, char[,] xmasArray)
        {
            int count = 0;
            string wordToCheck = "XMAS";
            List<List<(int x, int y)>> positionsToCheck = [
                [(1,0),(2,0),(3,0)],
                [(-1,0),(-2,0),(-3,0)],

                [(0,1),(0,2),(0,3)],
                [(0,-1),(0,-2),(0,-3)],

                [(1,1),(2,2),(3,3)],
                [(-1,-1),(-2,-2),(-3,-3)],

                [(1,-1),(2,-2),(3,-3)],
                [(-1,1),(-2,2),(-3,3)],
            ];

            foreach (var positionToCheck in positionsToCheck)
            {
                string word = "X";
                foreach (var position in positionToCheck)
                {
                    try
                    {
                        word += xmasArray[x + position.x, y + position.y];
                    }
                    catch { break; }
                }
                if (word == wordToCheck) count++;
            }
            return count;
        }
        private int GetCountForAllMasCases(int x, int y, char[,] xmasArray)
        {
            int count = 0;
            List<List<(int x, int y)>> positionsToCheck = [
                [(1,1),(-1,-1)],
                [(1,-1),(-1,1)],
            ];

            foreach (var positionToCheck in positionsToCheck)
            {
                string word = string.Empty;
                foreach (var position in positionToCheck)
                {
                    try
                    {
                        word += xmasArray[x + position.x, y + position.y];
                    }
                    catch { break; }
                }
                if (word is "MS" or "SM") count++;
            }
            return count == 2 ? 1 : 0;

        }

    }
}
