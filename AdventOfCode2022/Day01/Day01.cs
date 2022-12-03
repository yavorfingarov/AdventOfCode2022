namespace AdventOfCode2022.Day01
{
    public class Day01 : IDay
    {
        public object Part1(string input)
        {
            return input.GetLines()
                .ChunkOn(l => l == "")
                .Select(g => g.Sum(e => int.Parse(e)))
                .Max();
        }

        public object Part2(string input)
        {
            return input.GetLines()
                .ChunkOn(l => l == "")
                .Select(g => g.Sum(e => int.Parse(e)))
                .OrderByDescending(e => e)
                .Take(3)
                .Sum();
        }
    }
}
