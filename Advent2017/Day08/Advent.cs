using System.Collections.Generic;
using System.Linq;

namespace Advent2017.Day08
{
    public class Advent
    {
        public Dictionary<string, int> Register { get; }
        public int HigherValueDuringProcess { get; private set; } = 0;

        public Advent()
        {
            Register = new Dictionary<string, int>();
        }

        public List<string> GetInstructionParts(string expression)
        {
            return expression.Split(' ').ToList();
        }

        public int ProcessInstructionResult(List<string> instructionParts)
        {
            if (!Register.ContainsKey(instructionParts[0])) Register.Add(instructionParts[0], 0);
            if (!Register.ContainsKey(instructionParts[4])) Register.Add(instructionParts[4], 0);

            if (Compare(instructionParts[5], Register[instructionParts[4]], int.Parse(instructionParts[6])))
            {
                var variable = Register[instructionParts[0]];
                Register[instructionParts[0]] = instructionParts[1] == "inc" ? variable + int.Parse(instructionParts[2]) : variable - int.Parse(instructionParts[2]);
            }

            HigherValueDuringProcess = HigherValueDuringProcess < Register[instructionParts[0]] ? Register[instructionParts[0]] : HigherValueDuringProcess;

            return Register[instructionParts[0]];
        }

        private bool Compare(string operatorCompare, int x, int y)
        {
            switch (operatorCompare)
            {
                case "<": return x < y;
                case ">": return x > y;
                case "<=": return x <= y;
                case ">=": return x >= y;
                case "!=": return x != y;
                case "==": return x == y;
                default: return false;
            }
        }
    }
}
