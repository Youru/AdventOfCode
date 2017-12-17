using Advent2017;
using Advent2017.Day13;
using NFluent;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventTest
{
    public class AdventDay13Should
    {
        private Advent advent;
        private ReadFile reader;
        public AdventDay13Should()
        {
            advent = new Advent();
            reader = new ReadFile();
        }

        [Fact]
        public void Get_Firewall_Dictionnary()
        {
            var lines = reader.GetContentByLine("Day13ExFile");
            var layerDictionnary = advent.GetLayers(lines);

            Check.That(layerDictionnary.Count).Equals(lines.Count);
        }
        
        [Fact]
        public void Get_The_Layer_Caughted()
        {
            var lines = reader.GetContentByLine("Day13ExFile");
            var layerDictionnary = advent.GetLayers(lines);
            var picoSecondToRun = layerDictionnary.Last().Key;

            var list = advent.GetCaughtedLayer(layerDictionnary);

            Check.That(list).ContainsExactly(new List<int> { 0, 6 });
        }

        [Fact]
        public void Get_The_Severity_Of_Layers()
        {
            var lines = reader.GetContentByLine("Day13ExFile");
            var layerDictionnary = advent.GetLayers(lines);
            var layers = new List<int>() { 0, 6 };

            var severity = advent.CalculSeverity(layers, layerDictionnary);

            Check.That(severity).Equals(24);
        }
    }
}
