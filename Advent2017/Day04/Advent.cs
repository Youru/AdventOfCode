using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2017.Day04
{
    public class Advent
    {
        public bool GetPassPhraseWithoutDuplicateValidity(string passphrase)
        {
            var words = passphrase.Split(' ').GroupBy(w => w).Select(w => new { Count = w.Count() });

            return words.All(w => w.Count < 2);
        }

        public bool GetPassPhraseWithoutAnagramValidity(string passphrase)
        {
            var words = passphrase.Split(' ').Select(w => new { Word = w }).ToList();

            for (int i = 0; i < words.Count; i++)
            {
                for (int j = i + 1; j < words.Count; j++)
                {
                    if (IsAnagram(words[i].Word, words[j].Word))
                        return false;
                }
            }

            return true;
        }

        private bool IsAnagram(string word, string word2)
        {
            if (word.Length != word2.Length)
                return false;

            var countDown = word.Length;
            foreach (var character in word)
            {
                for (var i = 0; i < word2.Length; i++)
                {
                    if (character == word2[i])
                    {
                        countDown--;
                        word2 = word2.Remove(i,1);
                        break;
                    }
                }
            }

            return countDown == 0;
        }
    }
}
