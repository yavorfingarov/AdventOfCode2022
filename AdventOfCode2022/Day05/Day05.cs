using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day05
{
    public class Day05 : IDay
    {
        public object Part1(string input)
        {
            var chunks = input.GetLines()
                .ChunkOn(l => l == "");
            var stacks = CreateStacks(chunks.First().SkipLast(1).Reverse());
            var instructions = CreateInstructions(chunks.Last());
            foreach (var instruction in instructions)
            {
                for (var i = 0; i < instruction.Count; i++)
                {
                    stacks[instruction.To].Push(stacks[instruction.From].Pop());
                }
            }

            return string.Concat(stacks.Select(s => s.Peek()));
        }

        public object Part2(string input)
        {
            var chunks = input.GetLines()
                .ChunkOn(l => l == "");
            var stacks = CreateStacks(chunks.First().SkipLast(1).Reverse());
            var instructions = CreateInstructions(chunks.Last());
            var tempStack = new Stack<char>();
            foreach (var instruction in instructions)
            {
                for (var i = 0; i < instruction.Count; i++)
                {
                    tempStack.Push(stacks[instruction.From].Pop());
                }
                while (tempStack.Any())
                {
                    stacks[instruction.To].Push(tempStack.Pop());
                }
            }

            return string.Concat(stacks.Select(s => s.Peek()));
        }

        private static Stack<char>[] CreateStacks(IEnumerable<string> lines)
        {
            var stackCount = (lines.First().Length + 1) / 4;
            var stacks = new Stack<char>[stackCount];
            for (var i = 0; i < stackCount; i++)
            {
                stacks[i] = new Stack<char>();
            }
            foreach (var line in lines)
            {
                for (var i = 0; i < line.Length; i += 4)
                {
                    if (line[i + 1] != ' ')
                    {
                        stacks[i / 4].Push(line[i + 1]);
                    }
                }
            }

            return stacks;
        }

        private static IEnumerable<(int Count, int From, int To)> CreateInstructions(IList<string> lines)
        {
            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, @"move ([0-9]+) from ([0-9]+) to ([0-9]+)");

                yield return (
                    Count: int.Parse(matches[0].Groups[1].Value),
                    From: int.Parse(matches[0].Groups[2].Value) - 1,
                    To: int.Parse(matches[0].Groups[3].Value) - 1);
            }
        }
    }
}
