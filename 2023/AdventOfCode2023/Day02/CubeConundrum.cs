namespace AdventOfCode2023.Day02
{
    public class CubeConundrum
    {
        public List<int> GetIndexOfPossibleGames(List<string> games, Dictionary<string, int> numberColorInBag)
        {
            List<int> indexOfGames = new();

            var maxCubeColorByGames = GetMaxCubeColorByGames(games);
            for (int i = 0; maxCubeColorByGames.Count > i; i++)
            {
                var maxCubeColorByGame = maxCubeColorByGames[i];
                if (IsGamePossible(maxCubeColorByGame, numberColorInBag))
                    indexOfGames.Add(i+1);
            }
            return indexOfGames;
            bool IsGamePossible(Dictionary<string, int> maxCubeColorByGame, Dictionary<string, int> numberColorInBag)
            {
                foreach (var (key, value) in numberColorInBag)
                {
                    if (maxCubeColorByGame[key] > value) return false;
                }
                return true;
            }
        }


        public List<Dictionary<string, int>> GetMaxCubeColorByGames(List<string> games)
        {
            List<Dictionary<string, int>> CubeColorByGames = new();

            foreach (var game in games)
            {
                CubeColorByGames.Add(GetMaxCubeColorByGame(game));
            }
            return CubeColorByGames;
        }

        public Dictionary<string, int> GetMaxCubeColorByGame(string game)
        {
            Dictionary<string, int> maxCubeByColor = new();
            int indexOfGameSeparator = game.IndexOf(':');
            List<string> gameValuesByRound = game.Substring(indexOfGameSeparator + 1).Split(';').ToList();

            foreach (string gameValues in gameValuesByRound)
            {
                var values = gameValues.Split(',');
                foreach (string cubeValue in values)
                {
                    TryToUpdateMaxCubeByColor(maxCubeByColor, cubeValue);
                }
            }
            return maxCubeByColor;

            static void TryToUpdateMaxCubeByColor(Dictionary<string, int> maxCubeByColor, string cubeValue)
            {
                var numberByColor = cubeValue.Trim().Split(' ');
                int number = int.Parse(numberByColor[0]);
                string color = numberByColor[1];
                if (maxCubeByColor.TryGetValue(numberByColor[1], out int value))
                {
                    if (value < number)
                        maxCubeByColor[color] = number;
                }
                else
                    maxCubeByColor[color] = number;
            }
        }
    }
}
