namespace AdventOfCode2022.Day04
{
    public class Day04 : IDay
    {
        public object Part1(string input)
        {
            return input.GetLines()
                .Select(GetPairs)
                .Count(p => (p.Elf1.From >= p.Elf2.From && p.Elf1.To <= p.Elf2.To) ||
                    (p.Elf2.From >= p.Elf1.From && p.Elf2.To <= p.Elf1.To));
        }

        public object Part2(string input)
        {
            return input.GetLines()
                .Select(GetPairs)
                .Count(p => (p.Elf1.From >= p.Elf2.From && p.Elf1.From <= p.Elf2.To) ||
                    (p.Elf1.To <= p.Elf2.To && p.Elf1.To >= p.Elf2.From) ||
                    (p.Elf2.From >= p.Elf1.From && p.Elf2.From <= p.Elf1.To) ||
                    (p.Elf2.To <= p.Elf1.To && p.Elf2.To >= p.Elf1.From));
        }

        private static ((int From, int To) Elf1, (int From, int To) Elf2) GetPairs(string line)
        {
            var pairs = line.Split(',')
                .Select(p =>
                {
                    var numbers = p.Split('-');

                    return (From: int.Parse(numbers[0]), To: int.Parse(numbers[1]));
                })
                .ToArray();

            return (Elf1: pairs[0], Elf2: pairs[1]);
        }
    }
}
