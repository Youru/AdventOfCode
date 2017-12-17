using Advent2017.Extension;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Advent2017.Day13
{
    public class Advent
    {

        public Dictionary<int, int> GetLayers(List<string> lines)
        {
            var layerDictionnary = new Dictionary<int, int>();

            foreach (var line in lines)
            {
                var firewall = line.Split(":");
                layerDictionnary.Add(int.Parse(firewall[0]), int.Parse(firewall[1].Trim()));
            }

            return layerDictionnary;
        }

        public int GetDelayedPicoSecond(Dictionary<int, int> layerDictionnary)
        {
            var maxLayer = layerDictionnary.Last().Key + 1;
            var layerCaughted = new List<int>();
            var isLayerCaughted = true;
            var i = 0;

            while (isLayerCaughted)
            {
                isLayerCaughted = GetCaughtedLayer(layerDictionnary, i).Any();
                i++;
            }

            return --i;
        }

        public List<int> GetCaughtedLayer(Dictionary<int, int> layerDictionnary, int beginningPicoSecond = 0)
        {
            var maxLayer = layerDictionnary.Last().Key + 1;
            var layerCaughted = new List<int>();
            for (var i = beginningPicoSecond; i < beginningPicoSecond + maxLayer; i++)
            {
                var layer = (i - beginningPicoSecond) % maxLayer;
                if (layerDictionnary.ContainsKey(layer))
                {
                    var position = GetScannerPosition(layer, i, layerDictionnary);
                    if (position == 0)
                    {
                        layerCaughted.Add(i % maxLayer);
                    }
                }
            }

            return layerCaughted;
        }

        public int GetScannerPosition(int layer, int picoSecond, Dictionary<int, int> layerDictionnary) => picoSecond % (layerDictionnary[layer] * 2 - 2);
        public int CalculSeverity(List<int> layers, Dictionary<int, int> layerDictionnary) => layers.Sum(l => l * layerDictionnary[l]);
    }
}
