namespace AdventOfCode2022.Day01
{
    public class Day01 : IDay
    {
        public object Part1(string input)
        {
            var lines = $"{input}{Environment.NewLine}"
                .GetLines();
            var elfCalories = GetCalories(lines)
                .Select(g => g.Sum());

            return elfCalories.Max();
        }

        public object Part2(string input)
        {
            var lines = $"{input}{Environment.NewLine}"
                .GetLines();
            var elfCalories = GetCalories(lines)
                .Select(g => g.Sum())
                .OrderByDescending(e => e);

            return elfCalories.Take(3).Sum();
        }

        private static IEnumerable<List<int>> GetCalories(IEnumerable<string> lines)
        {
            var currentGroup = new List<int>();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    yield return currentGroup;

                    currentGroup = new List<int>();
                }
                else
                {
                    currentGroup.Add(int.Parse(line));
                }
            }
        }
    }
}
