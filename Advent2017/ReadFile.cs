using System.Collections.Generic;
using System.IO;

namespace Advent2017
{
    public class ReadFile
    {
        public string GetContent(string file)
        {
            string text = string.Empty;
            var fileStream = new FileStream($@"input\{file}.txt", FileMode.Open, FileAccess.Read);
            using (var reader = new StreamReader(fileStream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }

        public List<string> GetContentByLine(string file)
        {
            string line = string.Empty;
            var textByLine = new List<string>();
            var fileStream = new FileStream($@"input\{file}.txt", FileMode.Open, FileAccess.Read);

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
