using System.Text;

namespace AdventOfCode2024.Shared
{
    public static class ArrayHelper
    {
        public static char[,] ConvertToArray(List<string> list)
        {
            var array = new char[list.Count, list.First().Count()];
            foreach (var item in list.Select((value, i) => new { i, value }))
                for (int i = 0; i < item.value.Length; i++)
                {
                    array[item.i, i] = item.value[i];
                }

            return array;
        }

        public static string DisplayArray(char[,] array, List<char> keepValues = null)
        {
            StringBuilder display = new();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                string line = string.Empty;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (keepValues is null || keepValues?.Contains(array[i, j]) is true)
                        line += array[i, j];
                    else line += '.';
                }
                display.AppendLine(line);
            }

            return display.ToString();
        }
    }

    public record PositionMap(int X, int Y);
}
