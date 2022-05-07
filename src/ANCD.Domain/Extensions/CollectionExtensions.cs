namespace ANCD.Domain.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddConditionally<T>(this ICollection<T> collection, T value, Func<bool> condition)
        {
            if (condition()) collection.Add(value);
        }
    }
}
