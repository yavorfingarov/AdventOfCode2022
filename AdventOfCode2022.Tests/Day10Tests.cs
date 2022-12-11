using AdventOfCode2022.Day10;

namespace AdventOfCode2022.Tests
{
    public class Day10Tests : DayTests
    {
        [Fact]
        public void CpuTest()
        {
            var cpu = new Cpu();
            var instructions = new[]
            {
                "noop",
                "addx 3",
                "addx -5"
            };

            cpu.Run(instructions);

            Assert.Equal(new[] { 1, 1, 1, 4, 4 }, cpu.XValues);
        }

        [Fact]
        public override void Part2()
        {
            var expected = Environment.NewLine +
                "##..##..##..##..##..##..##..##..##..##.." + Environment.NewLine +
                "###...###...###...###...###...###...###." + Environment.NewLine +
                "####....####....####....####....####...." + Environment.NewLine +
                "#####.....#####.....#####.....#####....." + Environment.NewLine +
                "######......######......######......####" + Environment.NewLine +
                "#######.......#######.......#######....." + Environment.NewLine;
            var day = new Day10.Day10();

            var result = day.Part2(string.Join(Environment.NewLine, TestCasesPart1.Single().Input));

            Assert.Equal(expected, result);
        }

        public override List<TestCase> TestCasesPart1 => new()
        {
            new(13140, new[]
            {
                "addx 15",
                "addx -11",
                "addx 6",
                "addx -3",
                "addx 5",
                "addx -1",
                "addx -8",
                "addx 13",
                "addx 4",
                "noop",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx -35",
                "addx 1",
                "addx 24",
                "addx -19",
                "addx 1",
                "addx 16",
                "addx -11",
                "noop",
                "noop",
                "addx 21",
                "addx -15",
                "noop",
                "noop",
                "addx -3",
                "addx 9",
                "addx 1",
                "addx -3",
                "addx 8",
                "addx 1",
                "addx 5",
                "noop",
                "noop",
                "noop",
                "noop",
                "noop",
                "addx -36",
                "noop",
                "addx 1",
                "addx 7",
                "noop",
                "noop",
                "noop",
                "addx 2",
                "addx 6",
                "noop",
                "noop",
                "noop",
                "noop",
                "noop",
                "addx 1",
                "noop",
                "noop",
                "addx 7",
                "addx 1",
                "noop",
                "addx -13",
                "addx 13",
                "addx 7",
                "noop",
                "addx 1",
                "addx -33",
                "noop",
                "noop",
                "noop",
                "addx 2",
                "noop",
                "noop",
                "noop",
                "addx 8",
                "noop",
                "addx -1",
                "addx 2",
                "addx 1",
                "noop",
                "addx 17",
                "addx -9",
                "addx 1",
                "addx 1",
                "addx -3",
                "addx 11",
                "noop",
                "noop",
                "addx 1",
                "noop",
                "addx 1",
                "noop",
                "noop",
                "addx -13",
                "addx -19",
                "addx 1",
                "addx 3",
                "addx 26",
                "addx -30",
                "addx 12",
                "addx -1",
                "addx 3",
                "addx 1",
                "noop",
                "noop",
                "noop",
                "addx -9",
                "addx 18",
                "addx 1",
                "addx 2",
                "noop",
                "noop",
                "addx 9",
                "noop",
                "noop",
                "noop",
                "addx -1",
                "addx 2",
                "addx -37",
                "addx 1",
                "addx 3",
                "noop",
                "addx 15",
                "addx -21",
                "addx 22",
                "addx -6",
                "addx 1",
                "noop",
                "addx 2",
                "addx 1",
                "noop",
                "addx -10",
                "noop",
                "noop",
                "addx 20",
                "addx 1",
                "addx 2",
                "addx 2",
                "addx -6",
                "addx -11",
                "noop",
                "noop",
                "noop"
            })
        };

        public override List<TestCase> TestCasesPart2 => throw new NotImplementedException();
    }
}
