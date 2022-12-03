namespace AdventOfCode2022.Day03
{
    public class Day03 : IDay
    {
        public object Part1(string input)
        {
            return input.GetLines()
                .Select(l =>
                {
                    var chunks = l.Chunk(l.Length / 2);

                    return chunks.First().Intersect(chunks.Last());
                })
                .Select(d => d.Sum(c => c.ToPriority()))
                .Sum();
        }

        public object Part2(string input)
        {
            return input.GetLines()
                .Chunk(3)
                .Select(r => r[0].Intersect(r[1]).Intersect(r[2]))
                .Sum(c => c.Single().ToPriority());
        }
    }

    public static class ExtensionMethods
    {
        public static int ToPriority(this char c)
        {
            if (char.IsLower(c))
            {
                return c - 96;
            }

            return c - 38;
        }
    }
}
