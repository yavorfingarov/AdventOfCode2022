namespace AdventOfCode2022.Tests
{
    public class Day06Tests : DayTests
    {
        public override List<TestCase> TestCasesPart1 => new()
        {
            new(7, new[] { "mjqjpqmgbljsphdztnvjfqwrcgsmlb" }),
            new(5, new[] { "bvwbjplbgvbhsrlpgdmjqwftvncz" }),
            new(6, new[] { "nppdvjthqldpwncqszvftbrmjlhg" }),
            new(10, new[] { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" }),
            new(11, new[] { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" }),
        };

        public override List<TestCase> TestCasesPart2 => new()
        {
            new(19, new[] { "mjqjpqmgbljsphdztnvjfqwrcgsmlb" }),
            new(23, new[] { "bvwbjplbgvbhsrlpgdmjqwftvncz" }),
            new(23, new[] { "nppdvjthqldpwncqszvftbrmjlhg" }),
            new(29, new[] { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" }),
            new(26, new[] { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" }),
        };
    }
}
