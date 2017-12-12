using Advent2017;
using Advent2017.Day08;
using NFluent;
using System.Linq;
using Xunit;

namespace AdventTest
{
    public class AdventDay08Should
    {
        private Advent advent;
        public AdventDay08Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("b inc 5 if a > 1", 0)]
        [InlineData("b inc 5 if a == 0", 5)]
        [InlineData("b dec 5 if a <= 0", -5)]
        public void Get_Instruction_Result(string instruction, int resultExpected)
        {
            var instructionParts = advent.GetInstructionParts(instruction);
            advent.ProcessInstructionResult(instructionParts);
        }

        [Fact]
        public void Get_Processed_Instruction()
        {
            var reader = new ReadFile();
            var lines = reader.GetContentByLine("Day08ExFile");

            foreach (var line in lines)
            {
                var instructionParts = advent.GetInstructionParts(line);
                advent.ProcessInstructionResult(instructionParts);
            }

            Check.That(advent.Register.Max(r => r.Value)).Equals(1);
        }

        [Fact]
        public void Get_Higher_Value_During_Process()
        {
            var reader = new ReadFile();
            var lines = reader.GetContentByLine("Day08ExFile");

            foreach (var line in lines)
            {
                var instructionParts = advent.GetInstructionParts(line);
                advent.ProcessInstructionResult(instructionParts);
            }

            Check.That(advent.HigherValueDuringProcess).Equals(10);
        }
    }
}
