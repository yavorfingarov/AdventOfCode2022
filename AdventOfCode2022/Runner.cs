using System.Diagnostics;
using System.Text;

namespace AdventOfCode2022
{
    public interface IDay
    {
        object Part1(string input);

        object Part2(string input);
    }

    public class Runner
    {
        private readonly RunnerMode _RunnerMode;

        private readonly IEnumerable<Type> _Types;

        private readonly Stopwatch _Stopwatch = new();

        private readonly List<long> _Times = new();

        public Runner(RunnerMode runnerMode, string? singleDayName)
        {
            _RunnerMode = runnerMode;
            _Types = GetType().Assembly.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(IDay)))
                .OrderBy(t => t.Name)
                .AsEnumerable();
            if (_RunnerMode == RunnerMode.Latest)
            {
                _Types = _Types.TakeLast(1);
            }
            else if (_RunnerMode == RunnerMode.Single)
            {
                _Types = _Types.Where(t => t.Name == singleDayName);
            }
        }

        public void Run()
        {
            Console.WriteLine(Multiply(" *", 39));
            Console.WriteLine($"{Multiply("* ", 15)} {GetType().Namespace} {Multiply("* ", 15)}*");
            Console.WriteLine(Multiply(" *", 39));
            foreach (var type in _Types)
            {
                var day = (IDay)Activator.CreateInstance(type)!;
                Console.WriteLine($"{Multiply("=", 36)} {day.GetType().Name} {Multiply("=", 36)}");
                var input = File.ReadAllText(Path.Combine(day.GetType().Name, "Input.txt"));
                RunDayPart(1, () => day.Part1(input));
                RunDayPart(2, () => day.Part2(input));
            }
            if (_RunnerMode == RunnerMode.All)
            {
                _Times.Sort();
                var median = (double)(_Times[(_Times.Count / 2) - 1] + _Times[_Times.Count / 2]) / 2;
                Console.WriteLine(Multiply("=", 79));
                Console.WriteLine("{0,79}", $"    Min: {_Times.First(),5} ms");
                Console.WriteLine("{0,79}", $" Median: {Math.Round(median),5} ms");
                Console.WriteLine("{0,79}", $"Average: {Math.Round(_Times.Average()),5} ms");
                Console.WriteLine("{0,79}", $"    Max: {_Times.Last(),5} ms");
                Console.WriteLine("{0,79}", $"  Total: {_Times.Sum(),5} ms");
            }
        }

        private void RunDayPart(int part, Func<object> dayPart)
        {
            Console.Write($"Part{part}: ");
            object result;
            _Stopwatch.Restart();
            try
            {
                result = dayPart();
            }
            catch (NotImplementedException)
            {
                result = "Not implemented";
            }
            _Stopwatch.Stop();
            Console.Write($"{result,-64}");
            Console.WriteLine($"{_Stopwatch.ElapsedMilliseconds,5} ms");
            _Times.Add(_Stopwatch.ElapsedMilliseconds);
        }

        private static string Multiply(string input, int count)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < count; i++)
            {
                sb.Append(input);
            }

            return sb.ToString();
        }
    }

    public enum RunnerMode
    {
        Latest,
        Single,
        All
    }
}
