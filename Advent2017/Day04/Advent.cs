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
            var words = passphrase.Split(' ').Select(w => string.Concat(w.OrderBy(c => c)));

            return !words.All(w => (words.Skip(1)).Contains(w));
        }
    }
}
