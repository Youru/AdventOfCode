using AdventOfCode2023.Day01;
using AdventOfCode2023Tests.Common;
using FluentAssertions;

namespace AdventOfCode2023Tests.Day01
{
    public class TrebuchetTest
    {
        private readonly Trebuchet _trebuchet;
        private readonly string _basePath = "Day01/Input";

        public TrebuchetTest()
        {
            _trebuchet = new Trebuchet();
        }

        [Fact]
        public void Should_Get_Calibration_Value_From_First_And_Last_Digit()
        {
            string lineOfText = "1abc2";

            var calibrationValue = _trebuchet.GetCalibrationValue(lineOfText);

            calibrationValue.Should().Be("12");
        }

        [Fact]
        public void Should_Get_Calibration_Value_When_Only_One_Digit_Exist()
        {
            string lineOfText = "treb7uchet";

            var calibrationValue = _trebuchet.GetCalibrationValue(lineOfText);

            calibrationValue.Should().Be("77");

        }
        [Theory]
        [InlineData("1abc2", "12")]
        [InlineData("pqr3stu8vwx", "38")]
        [InlineData("a1b2c3d4e5f", "15")]
        [InlineData("treb7uchet", "77")]
        public void Should_Get_Correct_Calibration_Number_From_Line_Of_Text(string lineOfText, string expectedValue)
        {
            var calibrationValue = _trebuchet.GetCalibrationValue(lineOfText);

            calibrationValue.Should().Be(expectedValue);
        }
        [Fact]
        public void Should_Get_Correct_Document_Calibration_Value()
        {
            string documentText = """
                1abc2
                pqr3stu8vwx
                a1b2c3d4e5f
                treb7uchet
                """;
            var calibrationValue = _trebuchet.GetCalibrationDocumentValue(documentText.Split(Environment.NewLine).ToList());

            calibrationValue.Should().Be(142);
        }
        [Fact]
        public void Should_Get_Correct_Document_Calibration_Value_From_Input()
        {
            List<string> document = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            var calibrationValue = _trebuchet.GetCalibrationDocumentValue(document);

            calibrationValue.Should().Be(53312);
        }

        [Fact]
        public void Should_Get_Calibration_Value_From_First_And_Last_Digit_With_Spelled_Ones()
        {
            string lineOfText = "two1nine";

            var calibrationValue = _trebuchet.GetCalibrationValue(lineOfText);

            calibrationValue.Should().Be("29");
        }
        [Fact]
        public void Should_Get_Calibration_Value_From_First_And_Last_Digit_With_Merged_Spelled_Ones()
        {
            string lineOfText = "eightwo";

            var calibrationValue = _trebuchet.GetCalibrationValue(lineOfText);

            calibrationValue.Should().Be("82");
        }
        [Theory]
        [InlineData("two1nine", "29")]
        [InlineData("eightwothree", "83")]
        [InlineData("zoneight234", "14")]
        [InlineData("7pqrstsixteen", "76")]
        public void Should_Get_Correct_Calibration_Number_From_Line_Of_Text_With_Spelled_Ones(string lineOfText, string expectedValue)
        {
            var calibrationValue = _trebuchet.GetCalibrationValue(lineOfText);

            calibrationValue.Should().Be(expectedValue);
        }
        [Fact]
        public void Should_Get_Correct_Document_Calibration_Value_With_Spelled_Ones()
        {
            string documentText = """
                two1nine
                eightwothree
                abcone2threexyz
                xtwone3four
                4nineeightseven2
                zoneight234
                7pqrstsixteen
                """;
            var calibrationValue = _trebuchet.GetCalibrationDocumentValue(documentText.Split(Environment.NewLine).ToList());

            calibrationValue.Should().Be(281);
        }
    }
}