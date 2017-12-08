using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent2017.Day07
{
    public class Advent
    {
        public Program Parse(string programDetail)
        {
            Program program;
            var decomposition = programDetail.Split("->");
            Regex programRx = new Regex(@"\w*");
            Regex weightRx = new Regex(@"\d{1,}");
            program = new Program
            {
                Name = programRx.Match(decomposition[0]).Groups.First().Value.Trim(),
                Weight = int.Parse(weightRx.Match(decomposition[0]).Groups.First().Value)
            };

            if (decomposition.Length > 1)
            {
                program.Children = decomposition[1].Split(',').Select(d => new Program { Name = d.Trim() }).ToList();
            }

            return program;
        }

        public List<Program> GetUpdatedPrograms(List<Program> listProgram)
        {
            listProgram.ForEach(p => p.Children.ForEach(c =>
            {
                c.Weight = listProgram.First(lp => lp.Name == c.Name).Weight;
                c.Children = listProgram.First(lp => lp.Name == c.Name).Children;
            }));

            return listProgram;
        }

        public Program GetBottomProgram(List<Program> listProgram)
            => listProgram.FirstOrDefault(p => p.Children.Count > 0 && !listProgram.Any(x => x.Children.Any(c => c.Name == p.Name)));

        public Program GetTheUnbalancedTowerProgram(List<Program> listProgram)
             => listProgram.First(lp => lp.Children.Count > 0 && lp.Children.Sum(c => c.TotalWeight) / lp.Children.First().TotalWeight != lp.Children.Count);
    }

    public class Program
    {
        public Program() { Children = new List<Program>(); }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int TotalWeight { get { return Children.Sum(c => c.TotalWeight) + Weight; } }
        public List<Program> Children { get; set; }
    }
}
