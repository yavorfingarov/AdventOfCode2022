namespace AdventOfCode2022.Tests
{
    public class Day02Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new(15, new[] { "A Y", "B X", "C Z" })
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new(12, new[] { "A Y", "B X", "C Z" })
        };
    }
}
