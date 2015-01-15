using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace System.Linq
{
    public static class Extensions
    {
        public static IEnumerable<T> DivideIntoTwoAndGetTop<T>(this IEnumerable<T> collection)
        {
            var enumerable = collection as T[] ?? collection.ToArray();
            var count = enumerable.Count() / 2;

            for (int i = 0; i < count; i++)
            {
                yield return enumerable[i];
            }
        }
    }
}