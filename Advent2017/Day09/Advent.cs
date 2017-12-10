using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2017.Day09
{
    public class Advent
    {
        private Regex garbageRx = new Regex(@"<(.*?[^!.]|!{2})>");

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

        public int GetNumberPointByGroup(string stream)
        {
            stream = stream.Replace(",", "");
            var result = 0;
            var i = 0;
            while (i < stream.Length)
            {
                if (stream[i] == '{')
                {
                    var j = -1;
                    while (j + i >= 0 && stream[j + i] == '{')
                    {
                        j--;
                    }
                    result += Math.Abs(j);
                   i++;
                }
                else
                {
                    stream = stream.Remove(--i, 2);
                }
            }

            return result;
        }

        public string GetStreamWithoutGarbage(string stream)
        {
            return garbageRx.Replace(stream, "");
        }

        public int GetNumberCharacterDeleted(string stream)
        {
            return garbageRx.Matches(stream).Sum(m => m.Length - 2);
        }
    }
}
