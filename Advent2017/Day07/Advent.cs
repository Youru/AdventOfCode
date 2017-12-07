using Advent2017.Extension;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent2017.Day07
{
    public class Advent
    {
        public Program GetProgramDetail(string programDetail)
        {
            Program program;
            var decomposition = programDetail.Split("->");
            Regex programRx = new Regex(@"[a-z]*");
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

        public Program GetBottomProgram(List<Program> listProgram)
        {
            Program bottomProgram = null;

            foreach (var program in listProgram)
            {
                if (program.Children.Count > 0 && !listProgram.Any(x => x.Children.Any(c => c.Name == program.Name)))
                {
                    bottomProgram = program;
                    break;
                }
            }

            return bottomProgram;
        }

        public List<Program> ListProgramUpdated(List<Program> listProgram)
        {
            var programTmp = listProgram;
            foreach (var program in programTmp)
            {
                foreach (var children in program.Children)
                {
                    children.Weight = listProgram.First(lp => lp.Name == children.Name).Weight;
                    children.Children = listProgram.First(lp => lp.Name == children.Name).Children;
                }
            }

            return listProgram;
        }

        public Program GetTheUnbalancedTower(List<Program> listProgram)
        {
            return listProgram.First(lp => lp.Children.Count > 0 && lp.Children.Sum(c => c.TotalWeight) / lp.Children.First().TotalWeight != lp.Children.Count);
        }
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
