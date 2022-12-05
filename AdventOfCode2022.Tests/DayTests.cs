namespace AdventOfCode2022.Tests
{
    public abstract class DayTests
    {
        [Fact]
        public virtual void Part1()
        {
            Assert.NotEmpty(TestCasesPart1);
            foreach (var testCase in TestCasesPart1)
            {
                var day = CreateDay();
                var input = string.Join(Environment.NewLine, testCase.Input);
                var result = day.Part1(input);

                Assert.Equal(testCase.Expected, result);
            }
        }

        [Fact]
        public virtual void Part2()
        {
            Assert.NotEmpty(TestCasesPart2);
            foreach (var testCase in TestCasesPart2)
            {
                var day = CreateDay();
                var input = string.Join(Environment.NewLine, testCase.Input);
                var result = day.Part2(input);

                Assert.Equal(testCase.Expected, result);
            }
        }

        private IDay CreateDay()
        {
            var dayName = GetType().Name.Replace("Tests", null);
            var dayType = typeof(IDay).Assembly.GetExportedTypes()
                .Where(t => t.Name == dayName)
                .Single();
            var day = (IDay)Activator.CreateInstance(dayType)!;

            return day;
        }

        public abstract List<TestCase> TestCasesPart1 { get; }

        public abstract List<TestCase> TestCasesPart2 { get; }
    }

    public record TestCase(object Expected, string[] Input);
}
