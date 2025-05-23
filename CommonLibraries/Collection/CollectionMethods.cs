using System.Collections.Generic;

namespace Common.Collection
{
    public static class CollectionMethods
    {

        public static string ToLineList<T>(this IEnumerable<T> objects,
            string prompt, string indent = "")
        {

            return string.Concat(prompt, ":\n", indent,
                string.Join(string.Format("\n{0}", indent), objects));
        }
    }
}

