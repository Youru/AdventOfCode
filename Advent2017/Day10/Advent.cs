using Advent2017.Extension;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Advent2017.Day10
{
    public class Advent
    {
        public List<int> GetInputs(string inputs) => inputs.Split(',').Select(i => int.Parse(i)).ToList();
        public string GetASCIIInputs(string inputs) => string.Join(",", inputs.Select(i => (int)i).ToList());
        
        public List<int> GetHash(List<int> inputs, int length, int boucle)
        {
            var array = Enumerable.Range(0, length).ToArray();
            int position = 0;
            int skipSize = 0;
            for (var t = 0; t < boucle; t++)
            {
                foreach (var input in inputs)
                {
                    var arrayTmp = new List<int>();
                    for (var i = 0; i < input; i++)
                    {
                        arrayTmp.Add(array[(position + i) % length]);
                    }
                    arrayTmp.Reverse();

                    for (var i = 0; i < input; i++)
                    {
                        array[(position + i) % length] = arrayTmp[i];
                    }
                    position = (position + input + skipSize) % length;
                    skipSize++;
                }
            }

            return array.ToList();
        }

        public string CalculDenseHashInHexa(List<int> inputList,int boucle)
        {
            var denseHash = string.Empty;
            for (var i = 0; i < boucle; i++)
            {
                var result = 0;
                for (var j = 0; j < 16; j++)
                {
                    result ^= inputList[i * 16 + j];
                }
                denseHash += result.ToString("X2");
            }

            return denseHash;
        }
    }
}
