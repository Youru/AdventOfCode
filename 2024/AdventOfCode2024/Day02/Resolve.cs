namespace AdventOfCode2024.Day02
{
    public class Resolve
    {
        public int GetSafeReportNumber(List<string> list)
        {
            int safeReportNumber = 0;

            foreach (string line in list)
            {

                bool error = false;
                var numbers = line.Split(" ");
                bool isIncreasing = int.Parse(numbers[0]) - int.Parse(numbers[1]) < 0;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    int dif = int.Parse(numbers[i]) - int.Parse(numbers[i + 1]);
                    if (dif < -3 || dif > 3 || dif == 0)
                        error = true;

                    if (dif > 0 && isIncreasing || dif < 0 && !isIncreasing)
                        error = true;
                }

                if (!error)
                    safeReportNumber++;
            }

            return safeReportNumber;
        }
        public int GetSafeReportNumberWithDampener(List<string> list)
        {
            int safeReportNumber = 0;

            foreach (string line in list)
            {

                bool error = false;
                var numbers = line.Split(" ");
                bool isIncreasing = int.Parse(numbers[0]) - int.Parse(numbers[1]) < 0;
                List<string> errorsToRetry = [];
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    int dif = int.Parse(numbers[i]) - int.Parse(numbers[i + 1]);
                    if (dif < -3 || dif > 3 || dif == 0)
                        error = true;

                    if (dif > 0 && isIncreasing || dif < 0 && !isIncreasing)
                        error = true;
                }
                for (int i = 0; i < numbers.Length; i++)
                {
                    List<string> retry = [.. numbers];
                    retry.RemoveAt(i);
                    if (GetSafeReportNumber([string.Join(" ", retry)]) > 0)
                        error = false;
                }

                if (!error)
                    safeReportNumber++;
            }

            return safeReportNumber;
        }
    }
}
