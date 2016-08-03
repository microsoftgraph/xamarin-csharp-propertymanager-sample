using System.Collections.Generic;

namespace XamarinNativePropertyManager.Extensions
{
    public static class CollectionExtensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> source, IEnumerable<T> addSource)
        {
            foreach (var item in addSource)
            {
                source.Add(item);
            }
            return source;
        }
    }
}