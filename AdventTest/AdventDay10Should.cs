using Advent2017.Day10;
using NFluent;
using Xunit;

namespace AdventTest
{
    public class AdventDay10Should
    {
        private Advent advent;
        public AdventDay10Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("3", "2,1,0,3,4")]
        [InlineData("3,4", "4,3,0,1,2")]
        [InlineData("3,4,1,5", "3,4,2,1,0")]
        public void Reverse_List_By_Input(string inputs, string hashExpected)
        {
            var inputList = advent.GetInputs(inputs);
            var hash = advent.GetHash(inputList, 5, 1);

            Check.That(string.Join(",", hash)).Equals(hashExpected);
        }

        [Fact]
        public void Get_Ascii_input()
        {
            var ascii = advent.GetASCIIInputs("1,2,3");
            Check.That(ascii).Equals("49,44,50,44,51");
        }

        [Fact]
        public void Calcul_Dense_Harh()
        {
            var hash = "65,27,9,1,4,3,40,50,91,7,6,0,2,5,68,22";
            var inputList = advent.GetInputs(hash);
            var result = advent.CalculDenseHashInHexa(inputList,1);
            Check.That(result).Equals("40");
        }

        [Theory]
        //[InlineData("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [InlineData("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [InlineData("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [InlineData("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Calcul_Knot_Hash(string hash, string denseHashExpected)
        {
            var ascii = advent.GetASCIIInputs(hash) + ",17,31,73,47,23";
            var inputList = advent.GetInputs(ascii);
            var result = advent.CalculDenseHashInHexa(advent.GetHash(inputList, 256, 64),16);
            Check.That(result.ToLower()).Equals(denseHashExpected);
        }
    }
}
