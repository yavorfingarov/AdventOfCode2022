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
            throw new NotImplementedException();

            //var cpu = new Cpu();
            //cpu.Run(input.GetLines());
            //var sb = new StringBuilder();
            //for (var i = 0; i < cpu.XValues.Count; i++)
            //{
            //    var spritePosition = i % 40;
            //    if (spritePosition == 0)
            //    {
            //        sb.Append(Environment.NewLine);
            //    }
            //    if (i == 0 && (cpu.XValues[0] == 0 || cpu.XValues[1] == 0))
            //    {
            //        sb.Append('#');
            //    }
            //    else if (i == cpu.XValues.Count - 1 && (cpu.XValues[i - 1] == spritePosition || cpu.XValues[i] == spritePosition))
            //    {
            //        sb.Append('#');
            //    }
            //    else if (i > 0 && i < cpu.XValues.Count - 2 &&
            //        (cpu.XValues[i - 1] == spritePosition || cpu.XValues[i] == spritePosition || cpu.XValues[i + 1] == spritePosition))
            //    {
            //        sb.Append('#');
            //    }
            //    else
            //    {
            //        sb.Append('.');
            //    }
            //}

            //return sb.Append(Environment.NewLine).ToString();
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
