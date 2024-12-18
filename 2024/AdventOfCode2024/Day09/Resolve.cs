using System.Collections;

namespace AdventOfCode2024.Day09
{
    public class Resolve
    {
        public long GetFileSystemChecksum(string field)
        {
            Queue queueIndexZero = new();
            Stack<int> queueIndexNumber = new();
            List<string> disk = ConstructDisk(field, queueIndexZero, queueIndexNumber);
            MoveFileBlock(queueIndexZero, queueIndexNumber, disk);
            return CalculSum(disk);
        }
        public long GetFileSystemChecksumForCompleteFile(string field)
        {
            Queue queueIndexZero = new();
            Stack<int> queueIndexNumber = new();
            List<string> disk = ConstructDisk(field, queueIndexZero, queueIndexNumber);
            MoveFileBlockWithEntireFile(queueIndexZero, queueIndexNumber, disk);
            return CalculSum(disk);
        }

        private static List<string> ConstructDisk(string field, Queue queueIndexZero, Stack<int> queueIndexNumber)
        {
            int currentIndex = 0;
            List<string> disk = [];
            for (int i = 0; i < field.Length; i++)
            {
                int number = (int)char.GetNumericValue(field[i]);
                string block = i % 2 == 1 ? "." : $"{i / 2}";
                foreach (var r in Enumerable.Range(1, number))
                {
                    if (block is ".") queueIndexZero.Enqueue(currentIndex + r - 1);
                    else queueIndexNumber.Push(currentIndex + r - 1);
                    disk.Add(block);
                };
                currentIndex += number;
            }
            return disk;
        }

        private static void MoveFileBlock(Queue queueIndexZero, Stack<int> queueIndexNumber, List<string> disk)
        {
            foreach (var _ in Enumerable.Range(0, queueIndexZero.Count))
            {
                var indexZero = (int)queueIndexZero.Dequeue();
                var indexNumber = queueIndexNumber.Pop();
                if (indexZero > indexNumber) break;
                disk[indexZero] = disk[indexNumber];
                disk[indexNumber] = ".";
            }
        }
        private static void MoveFileBlockWithEntireFile(Queue queueIndexZero, Stack<int> queueIndexNumber, List<string> disk)
        {
            RangeIndex nextRangeIndexZero = new(0, 0);
            RangeIndex nextRangeIndexNumber = new(0, 0);

            Dictionary<int, int?> rangesZero = GetRangesZero();
            Queue<RangeIndex> rangesNumber = GetRangesNumber();
            while (rangesNumber.Count > 0)
            {
                var range = rangesNumber.Dequeue();
                var rangeZero = rangesZero.OrderBy(z => z.Key).FirstOrDefault(z => z.Value >= range.number);
                if (rangeZero.Value is null || rangeZero.Key > range.index) continue;
                foreach (var n in Enumerable.Range(0, range.number))
                {
                    disk[rangeZero.Key + n] = disk[range.index + n];
                    disk[range.index + n] = ".";
                }
                rangesZero[rangeZero.Key] = 0;
                var remaining = rangeZero.Value - range.number;
                if (remaining is not 0)
                    rangesZero.Add(rangeZero.Key + range.number, remaining);
            }

            Dictionary<int, int?> GetRangesZero()
            {
                Dictionary<int, int?> rangesZero = [];
                while (queueIndexZero.Count > 0)
                {
                    var range = GetFirstRangeZero();
                    rangesZero.Add(range.index, range.number);
                }
                return rangesZero;
            }

            RangeIndex GetFirstRangeZero()
            {
                int index = nextRangeIndexZero.index is 0? (int)queueIndexZero.Dequeue() : nextRangeIndexZero.index;
                int nextIndex = 0;
                int dif = 0;
                int number = nextRangeIndexZero.number;
                while (dif < 2 && queueIndexZero.Count > 0)
                {
                    nextIndex = (int)queueIndexZero.Dequeue();
                    dif = (int)nextIndex - index;
                    number++;
                    if (dif < 2 && queueIndexZero.Count > 0)
                        index = nextIndex;
                }
                nextRangeIndexZero = nextRangeIndexZero with { index = nextIndex, number = 0 };
                return new(index - number + 1, number);
            }

            Queue<RangeIndex> GetRangesNumber()
            {
                Queue<RangeIndex> rangesNumbers = [];
                while (queueIndexNumber.Count > 0)
                {
                    rangesNumbers.Enqueue(GetLastRangeNumber());
                }
                if (nextRangeIndexNumber.index is not -1) rangesNumbers.Enqueue(nextRangeIndexNumber);
                return rangesNumbers;
            }
            RangeIndex GetLastRangeNumber()
            {
                int index = nextRangeIndexNumber.index is 0 ? queueIndexNumber.Pop() : nextRangeIndexNumber.index;
                int nextIndex = 0;
                int value = int.Parse(disk[index]);
                int nextValue = 0;
                int number = 1;
                while (value == nextValue && queueIndexNumber.Count > 0)
                {
                    nextIndex = queueIndexNumber.Pop();
                    nextValue = int.Parse(disk[nextIndex]);
                    if (value == nextValue)
                        number++;
                }
                nextRangeIndexNumber = nextRangeIndexNumber with { index = value != nextValue ? nextIndex : -1, number = value != nextValue ? 1 : number + 1 };
                return new(index - number + 1, number);
            }
        }

        private static long CalculSum(List<string> disk)
        {
            long sum = 0;
            foreach (var i in Enumerable.Range(0, disk.Count))
            {
                if (disk[i] is ".") continue;
                sum += i * int.Parse(disk[i]);
            }

            return sum;
        }
    }

    public record RangeIndex(int index, int number);

}