namespace AdventOfCode2022.Tests
{
    public class Day05Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new("CMZ", new[]
            {
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                " 1   2   3 ",
                "",
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2"
            })
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new("MCD", new[]
            {
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                " 1   2   3 ",
                "",
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2"
            })
        };
    }
}
