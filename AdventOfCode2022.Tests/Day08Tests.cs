namespace AdventOfCode2022.Tests
{
    public class Day08Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new(21, new[]
            {
                "30373",
                "25512",
                "65332",
                "33549",
                "35390"
            })
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new(8, new[]
            {
                "30373",
                "25512",
                "65332",
                "33549",
                "35390"
            })
        };
    }
}
