namespace AdventOfCode2022.Shared
{
    public static class ExtensionMethods
    {
        public static IEnumerable<string> GetLines(this string input,
            StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            return input.Split(new[] { "\r\n", "\r", "\n" }, stringSplitOptions);
        }

        public static IEnumerable<IList<T>> ChunkOn<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var group = new List<T>();
            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return group;

                    group = new List<T>();
                }
                else
                {
                    group.Add(element);
                }
            }

            yield return group;
        }
    }
}
