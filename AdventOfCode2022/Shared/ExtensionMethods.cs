namespace AdventOfCode2022.Shared
{
    public static class ExtensionMethods
    {
        public static IEnumerable<string> GetLines(this string input)
        {
            return input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .ToList();
        }
    }
}
