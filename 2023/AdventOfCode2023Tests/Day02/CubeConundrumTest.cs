using AdventOfCode2023.Day02;
using FluentAssertions;
using AdventOfCode2023Tests.Common;

namespace AdventOfCode2023Tests.Day02
{
    public class CubeConundrumTest
    {
        private readonly CubeConundrum _cubeConundrum;
        private readonly string _basePath = "Day02/Input";

        public CubeConundrumTest()
        {
            _cubeConundrum = new CubeConundrum();
        }
        [Fact]
        public void Game_Should_Be_Possible_With_X_Types_Of_Cubes()
        {
            string game = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

            var cubeByGame = _cubeConundrum.GetMaxCubeColorByGame(game);

            cubeByGame.Should().Contain("blue", 6);
            cubeByGame.Should().Contain("red", 4);
            cubeByGame.Should().Contain("green", 2);
        }
        [Fact]
        public void Should_Get_Correct_Power_Of_Game()
        {
            string game = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";

            var cubeByGame = _cubeConundrum.GetMaxCubeColorByGame(game);

            var power = cubeByGame.Select(c => c.Value).Aggregate((x, y) => x * y);

            power.Should().Be(48);
        }

        [Fact]
        public void Should_Return_Correct_Sum_Id_Of_Possible_Game()
        {
            string games = """
                Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                """;
            Dictionary<string, int> numberColorInBag = new()
            {
                ["red"] = 12,
                ["green"] = 13,
                ["blue"] = 14,
            };
            var indexOfGames = _cubeConundrum.GetIndexOfPossibleGames(games.Split(Environment.NewLine).ToList(), numberColorInBag);

            indexOfGames.Sum().Should().Be(8);
        }
        [Fact]
        public void Should_Get_Correct_Sum_Of_Value_From_Input()
        {
            Dictionary<string, int> numberColorInBag = new()
            {
                ["red"] = 12,
                ["green"] = 13,
                ["blue"] = 14,
            };
            List<string> games = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            var indexOfGames = _cubeConundrum.GetIndexOfPossibleGames(games, numberColorInBag);

            indexOfGames.Sum().Should().Be(2600);
        }
        [Fact]
        public void Should_Get_Correct_Sum_Of_Power_From_Input()
        {
            List<string> games = FileHelper.GetContentByLine(_basePath, "Input1.txt");
            var maxCubeColorByGame = _cubeConundrum.GetMaxCubeColorByGames(games);
            int sumPower = 0;
            foreach (var game in maxCubeColorByGame)
            {

                var power = game.Select(c => c.Value).Aggregate((x, y) => x * y);
                sumPower += power;
            }

            sumPower.Should().Be(86036);
        }

    }
}
