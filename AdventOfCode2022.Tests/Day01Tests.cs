namespace AdventOfCode2022.Tests
{
    public class Day01Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new(24000, new[]
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000"
            })
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new(45000, new[]
            {
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000"
            })
        };
    }
}
