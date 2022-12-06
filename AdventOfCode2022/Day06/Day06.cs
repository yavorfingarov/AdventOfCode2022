namespace AdventOfCode2022.Day06
{
    public class Day06 : IDay
    {
        public object Part1(string input)
        {
            return GetProcessedCount(input, markerLength: 4);
        }

        public object Part2(string input)
        {
            return GetProcessedCount(input, markerLength: 14);
        }

        private static int GetProcessedCount(string input, int markerLength)
        {
            for (var i = markerLength - 1; i < input.Length; i++)
            {
                var hashSet = new HashSet<char>(input.Substring(i - markerLength + 1, markerLength));
                if (hashSet.Count == markerLength)
                {
                    return i + 1;
                }
            }

            return input.Length;
        }
    }
}
