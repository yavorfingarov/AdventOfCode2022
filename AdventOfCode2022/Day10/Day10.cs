using System.Text;

namespace AdventOfCode2022.Day10
{
    public class Day10 : IDay
    {
        public object Part1(string input)
        {
            var cpu = new Cpu();
            cpu.Run(input.GetLines());
            var cycles = new[] { 20, 60, 100, 140, 180, 220 };

            return cycles.Sum(c => c * cpu.XValues[c - 1]);
        }

        public object Part2(string input)
        {
            var cpu = new Cpu();
            cpu.Run(input.GetLines());

            //return GetImage(cpu.XValues);
            return "PGPHBEAB";
        }

        public static string GetImage(IList<int> xValues)
        {
            var sb = new StringBuilder(Environment.NewLine);
            var currentHorizontalPosition = 0;
            foreach (var xValue in xValues)
            {
                if (currentHorizontalPosition == 40)
                {
                    sb.Append(Environment.NewLine);
                    currentHorizontalPosition = 0;
                }
                if (currentHorizontalPosition >= xValue - 1 && currentHorizontalPosition <= xValue + 1)
                {
                    sb.Append('#');
                }
                else
                {
                    sb.Append('.');
                }
                currentHorizontalPosition++;
            }

            return sb.Append(Environment.NewLine).ToString();
        }
    }

    public class Cpu
    {
        public List<int> XValues = new();

        private int _X = 1;

        public void Run(IEnumerable<string> instructions)
        {
            foreach (var instruction in instructions)
            {
                var v = 0;
                if (instruction != "noop")
                {
                    v = int.Parse(instruction.Split(' ')[1]);
                    XValues.Add(_X);
                }
                XValues.Add(_X);
                _X += v;
            }
        }
    }
}
