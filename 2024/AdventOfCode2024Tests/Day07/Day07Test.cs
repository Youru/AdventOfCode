using AdventOfCode2024.Day07;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day07
{
    public class Day07Test
    {
        private readonly string _basePath = "Day07/Input";
        private readonly Resolve _resolve;

        public Day07Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Sum_Correct_Equation()
        {
            string documentText = """
                190: 10 19
                3267: 81 40 27
                83: 17 5
                156: 15 6
                7290: 6 8 6 15
                161011: 16 10 13
                192: 17 8 14
                21037: 9 7 18 13
                292: 11 6 16 20
                """;
            long sumCorrectEquation = _resolve.GetSumCorrectEquation(documentText.Split(Environment.NewLine).ToList());

            sumCorrectEquation.Should().Be(3749);
        }
        [Fact]
        public void Get_Sum_Correct_With_Third_Operator_Equation()
        {
            string documentText = """
                7290: 6 8 6 15
                156: 15 6
                192: 17 8 14
                190: 10 19
                3267: 81 40 27
                83: 17 5
                161011: 16 10 13
                21037: 9 7 18 13
                292: 11 6 16 20
                """;
            long sumCorrectEquation = _resolve.GetSumCorrectEquationWithThirdOperator(documentText.Split(Environment.NewLine).ToList());

            sumCorrectEquation.Should().Be(11387);
        }
        [Fact]
        public void Get_Sum_Correct_Equation_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            long sumCorrectEquation = _resolve.GetSumCorrectEquation(document);

            sumCorrectEquation.Should().Be(663613490587L);
        }
        //[Fact]
        public void Get_Sum_Correct_With_Third_Operator_Equation_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            long sumCorrectEquation = _resolve.GetSumCorrectEquationWithThirdOperator(document);

            sumCorrectEquation.Should().Be(110365987435001L);
        }
    }
}