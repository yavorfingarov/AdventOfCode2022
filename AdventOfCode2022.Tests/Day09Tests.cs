namespace AdventOfCode2022.Tests
{
    public class Day09Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new(13, new[]
            {
                "R 4",
                "U 4",
                "L 3",
                "D 1",
                "R 4",
                "D 1",
                "L 5",
                "R 2"
            })
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new(1, new[]
            {
                "R 4",
                "U 4",
                "L 3",
                "D 1",
                "R 4",
                "D 1",
                "L 5",
                "R 2"
            })
        };
    }
}
