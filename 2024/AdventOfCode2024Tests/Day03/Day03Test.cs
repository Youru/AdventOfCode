using AdventOfCode2024.Day03;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day03
{
    public class Day03Test
    {
        private readonly string _basePath = "Day03/Input";
        private readonly Resolve _resolve;

        public Day03Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Multiplication_Result()
        {
            string documentText = """
                xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
                """;
            int multiplicationResult = _resolve.GetMultiplicationResult(documentText.Split(Environment.NewLine).ToList());

            multiplicationResult.Should().Be(161);
        }
        [Fact]
        public void Get_Multiplication_Result_With_Condition()
        {
            string documentText = """
                xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
                """;
            int multiplicationResult = _resolve.GetMultiplicationResultWithCondition(documentText.Split(Environment.NewLine).ToList());

            multiplicationResult.Should().Be(48);
        }
        [Fact]
        public void Get_Multiplication_Result_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int multiplicationResult = _resolve.GetMultiplicationResult(document);

            multiplicationResult.Should().Be(157621318);
        }
        [Fact]
        public void Get_Multiplication_Result_With_Condition_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            int multiplicationResult = _resolve.GetMultiplicationResultWithCondition(document);

            multiplicationResult.Should().Be(79845780);
        }
    }
}