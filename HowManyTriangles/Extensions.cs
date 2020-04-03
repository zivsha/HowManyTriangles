using System;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> FindConsecutiveGroups<T>(this IEnumerable<T> sequence, Predicate<T> predicate, int count)
        {
            IEnumerable<T> current = sequence;

            while (current.Count() >= count)
            {
                IEnumerable<T> window = current.Take(count);

                if (window.Where(x => predicate(x)).Count() >= count)
                {
                    yield return window;
                }

                current = current.Skip(1);
            }
        }
    }
}
