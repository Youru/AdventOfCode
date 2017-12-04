using System.Collections.Generic;
using System.Linq;
namespace Advent2017.Extension
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Determines whether a sequence contains duplicated elements.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns>true if the source sequence contains duplicated elements; otherwise, false.</returns>
        public static bool Duplicate<TSource>(this IEnumerable<TSource> source)
           => source.GroupBy(s => s)
           .Select(s => new { Count = s.Count() })
           .All(s => s.Count < 2);
    }
}
