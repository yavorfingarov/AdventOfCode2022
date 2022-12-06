namespace AdventOfCode2022.Day06
{
    public class Day06 : IDay
    {
        public object Part1(string input)
        {
            for (var i = 3; i < input.Length; i++)
            {
                var hashSet = new HashSet<char>(input.Substring(i - 3, 4));
                if (hashSet.Count == 4)
                {
                    return i + 1;
                }
            }

            throw new InvalidOperationException();
        }

        public object Part2(string input)
        {
            for (var i = 13; i < input.Length; i++)
            {
                var hashSet = new HashSet<char>(input.Substring(i - 13, 14));
                if (hashSet.Count == 14)
                {
                    return i + 1;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
