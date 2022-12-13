namespace AdventOfCode2022.Tests
{
    public class Day12Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new(31, new[]
            {
                "Sabqponm",
                "abcryxxl",
                "accszExk",
                "acctuvwj",
                "abdefghi"
            })
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new(29, new[]
            {
                "Sabqponm",
                "abcryxxl",
                "accszExk",
                "acctuvwj",
                "abdefghi"
            })
        };
    }
}
