namespace AdventOfCode2023Tests.Common
{
    public static class FileHelper
    {
        public static string GetContent(string basePath, string file)
        {
            string text = string.Empty;
            var fileStream = new FileStream($@"{basePath}\{file}", FileMode.Open, FileAccess.Read);
            using (var reader = new StreamReader(fileStream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        public static List<string> GetContentByLine(string basePath, string file)
        {
            string line = string.Empty;
            var textByLine = new List<string>();
            var fileStream = new FileStream($@"{basePath}\{file}", FileMode.Open, FileAccess.Read);

            using (var reader = new StreamReader(fileStream))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    textByLine.Add(line);
                }
            }

            return textByLine;
        }

    }
}
