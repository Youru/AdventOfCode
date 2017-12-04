using Advent2017.Extension;
using System.Linq;

namespace Advent2017.Day04
{
    public class Advent
    {
        public bool GetPassPhraseWithoutDuplicateValidity(string passphrase)
            => passphrase.Split(' ')
                .Duplicate();

        public bool GetPassPhraseWithoutAnagramValidity(string passphrase)
            => passphrase.Split(' ')
                .Select(w => string.Concat(w.OrderBy(c => c)))
                .Duplicate();
    }
}
