using Advent2017;
using Advent2017.Day09;
using NFluent;
using System.Linq;
using Xunit;

namespace AdventTest
{
    public class AdventDay9Should
    {
        private Advent advent;
        public AdventDay9Should()
        {
            advent = new Advent();
        }

        [Theory]
        [InlineData("<>", "<>")]
        [InlineData("<<<<>", "<<<<>")]
        [InlineData("<{!>}>", "<{}>")]
        [InlineData("<!!>", "<>")]
        [InlineData("<!,{,!}!>!i>", "<{,>")]
        [InlineData("<!!!>>", "<>")]
        [InlineData("<{o\"i!a,<{i<a>", "<{o\"i,<{i<a>")]
        public void Remove_Ignored_Character(string stream, string garbageExpected)
        {
            var result = advent.GetStreamWithCanceledGarbage(stream);

            Check.That(result).Equals(garbageExpected);
        }

        [Theory]
        [InlineData("{{<!>>},{<!>},{<!>},{<a>}}", "{{},{}}")]
        public void Get_Number_Gargabe(string stream, string streamExpected)
        {
            stream = advent.GetStreamWithCanceledGarbage(stream);
            stream = advent.GetStreamWithoutGarbage(stream);

            Check.That(stream).Equals(streamExpected);
        }

        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}", 16)]
        [InlineData("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3)]
        public void Get_Number_Point(string stream, int pontExpected)
        {
            stream = advent.GetStreamWithCanceledGarbage(stream);
            stream = advent.GetStreamWithoutGarbage(stream);
            var point = advent.GetNumberPointByGroup(stream);
            Check.That(point).Equals(pontExpected);
        }

        [Theory]
        [InlineData("<>", 0)]
        [InlineData("<random characters>", 17)]
        [InlineData("<!!>", 0)]
        [InlineData("<{o\"i!a,<{i<a>", 10)]
        public void Get_Number_Deleted_Character(string stream, int numberDeletedCharacterExpected)
        {
            stream = advent.GetStreamWithCanceledGarbage(stream);
            var numberDeletedCharacter = advent.GetNumberCharacterDeleted(stream);
            Check.That(numberDeletedCharacter).Equals(numberDeletedCharacterExpected);
        }
    }
}
