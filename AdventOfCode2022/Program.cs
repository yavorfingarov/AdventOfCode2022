namespace AdventOfCode2022
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var runnerMode = RunnerMode.Latest;
            string? singleDayName = null;
            if (args.SequenceEqual(new[] { "All" }))
            {
                runnerMode = RunnerMode.All;
            }
            else if (args.Length == 1)
            {
                runnerMode = RunnerMode.Single;
                singleDayName = args[0];
            }
            var runner = new Runner(runnerMode, singleDayName);
            runner.Run();
        }
    }
}
