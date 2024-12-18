using AdventOfCode2024.Day08;
using AdventOfCode2024Tests.Common;
using FluentAssertions;

namespace AdventOfCode2024Tests.Day08
{
    public class Day08Test
    {
        private readonly string _basePath = "Day08/Input";
        private readonly Resolve _resolve;

        public Day08Test()
        {
            _resolve = new Resolve();
        }

        [Fact]
        public void Get_Number_Of_Unique_Localisation()
        {
            string documentText = """
                ............
                ........0...
                .....0......
                .......0....
                ....0.......
                ......A.....
                ............
                ............
                ........A...
                .........A..
                ............
                ............
                """;
            long numberOfUniqueLocalisation = _resolve.GetNumberOfUniqueLocalisation(documentText.Split(Environment.NewLine).ToList());

            numberOfUniqueLocalisation.Should().Be(14);
        }
        [Fact]
        public void Get_Number_Of_Unique_Localisation_Resonant_Harmonic()
        {
            string documentText = """
                ............
                ........0...
                .....0......
                .......0....
                ....0.......
                ......A.....
                ............
                ............
                ........A...
                .........A..
                ............
                ............
                """;
            long numberOfUniqueLocalisation = _resolve.GetNumberOfUniqueLocalisationWithResonantHarmonic(documentText.Split(Environment.NewLine).ToList());

            numberOfUniqueLocalisation.Should().Be(34);
        }
        [Fact]
        public void Get_Number_Of_Unique_Localisation_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            long numberOfUniqueLocalisation = _resolve.GetNumberOfUniqueLocalisation(document);

            numberOfUniqueLocalisation.Should().Be(413);
        }
        [Fact]
        public void Get_Number_Of_Unique_Localisation_Resonant_Harmonic_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            long numberOfUniqueLocalisation = _resolve.GetNumberOfUniqueLocalisationWithResonantHarmonic(document);

            numberOfUniqueLocalisation.Should().Be(1417);
        }
    }
}