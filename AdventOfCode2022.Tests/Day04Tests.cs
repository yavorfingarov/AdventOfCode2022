namespace AdventOfCode2022.Tests
{
    public class Day04Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new(2, new[]
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            })
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new(4, new[]
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            })
        };
    }
}
