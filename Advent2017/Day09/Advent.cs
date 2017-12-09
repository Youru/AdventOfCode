using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2017.Day09
{
    public class Advent
    {
        public string GetStreamWithCanceledGarbage(string garbage)
        {
            var i = 0;
            while (i < garbage.Length)
            {
                if (garbage[i] == '!')
                {
                    garbage = garbage.Remove(i, 2);
                }
                else
                {
                    i++;
                }
            }

            return garbage;
        }

        public string GetStreamWithoutGarbage(string stream)
        {
            Regex garbageRx = new Regex(@"<(.*?)>");
            stream = garbageRx.Replace(stream, "");

            return stream;
        }

        public int GetNumberPointByGroup(string stream)
        {
            stream = stream.Replace(",", "");
            var result = 0;
            var i = 0;
            while (i < stream.Length)
            {
                if (stream[i] == '{')
                {
                    result++;

                    var j = -1;
                    while (j + i >= 0 && stream[j + i] == '{')
                    {
                        result++;
                        j--;
                    }
                    i++;
                }
                else
                {
                    stream = stream.Remove(i - 1, 2);
                    i--;
                }
            }

            return result;
        }

        public int GetNumberCharacterDeleted(string stream)
        {
            Regex garbageRx = new Regex(@"<(.*?)>");
            return garbageRx.Matches(stream).Sum(m => m.Length - 2);
        }
    }
}
