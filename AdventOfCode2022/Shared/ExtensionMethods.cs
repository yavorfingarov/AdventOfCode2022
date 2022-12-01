namespace AdventOfCode2022.Shared
{
    public static class ExtensionMethods
    {
        public static IEnumerable<string> GetLines(this string input,
            StringSplitOptions stringSplitOptions = StringSplitOptions.None)
        {
            return input.Split(new[] { "\r\n", "\r", "\n" }, stringSplitOptions);
        }
    }
}
