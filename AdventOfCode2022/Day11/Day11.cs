using System.Linq.Expressions;
using System.Numerics;

namespace AdventOfCode2022.Day11
{
    public class Day11 : IDay
    {
        public object Part1(string input)
        {
            var monkeys = input.GetLines()
                .ChunkOn(l => l == "")
                .Select(c => new Monkey(c, item => item / 3))
                .ToList();
            var simulation = new Simulation(monkeys);
            simulation.Run(rounds: 20);

            return simulation.GetMonkeyBusinessLevel();
        }

        public object Part2(string input)
        {
            BigInteger divider = 2 * 3 * 5 * 7 * 11 * 13 * 17 * 19 * 23;
            var monkeys = input.GetLines()
                .ChunkOn(l => l == "")
                .Select(c => new Monkey(c, item => item % divider))
                .ToList();
            var simulation = new Simulation(monkeys);
            simulation.Run(rounds: 10_000);

            return simulation.GetMonkeyBusinessLevel();
        }
    }

    public class Monkey
    {
        public long Inspections { get; private set; } = 0;

        private readonly Queue<BigInteger> _Items;

        private readonly Func<BigInteger, BigInteger> _Manage;

        private readonly Func<BigInteger, BigInteger> _Operation;

        private readonly Func<BigInteger, int> _Recipient;

        public Monkey(IList<string> description, Func<BigInteger, BigInteger> manage)
        {
            var items = description[1].Split(": ")[1].Split(",");
            _Items = new(items.Select(BigInteger.Parse));
            var operationTokens = description[2].Split("new = old ")[1].Split(' ');
            _Operation = CreateOperationDelegate(operationTokens[0], operationTokens[1]);
            var divider = description[3].Split("by ")[1];
            var trueRecipient = description[4].Split("monkey ")[1];
            var falseRecipient = description[5].Split("monkey ")[1];
            _Recipient = CreateRecipientDelegate(divider, trueRecipient, falseRecipient);
            _Manage = manage;

        }

        public IEnumerable<(int Monkey, BigInteger Item)> ThrowItems()
        {
            while (_Items.TryDequeue(out var item))
            {
                item = _Operation(item);
                item = _Manage(item);
                Inspections++;
                var recipient = _Recipient(item);

                yield return (recipient, item);
            }
        }

        public void Receive(BigInteger item)
        {
            _Items.Enqueue(item);
        }

        private static Func<BigInteger, BigInteger> CreateOperationDelegate(string arithmeticOperator, string argument)
        {
            var item = Expression.Parameter(typeof(BigInteger));
            Expression argumentValue = argument switch
            {
                "old" => item,
                _ => Expression.Constant(BigInteger.Parse(argument))
            };
            var result = arithmeticOperator switch
            {
                "+" => Expression.Add(item, argumentValue),
                "*" => Expression.Multiply(item, argumentValue),
                _ => throw new InvalidOperationException()
            };
            var lambda = Expression.Lambda<Func<BigInteger, BigInteger>>(result, new[] { item });

            return lambda.Compile();
        }

        private static Func<BigInteger, int> CreateRecipientDelegate(string divider, string trueRecipient, string falseRecipient)
        {
            var item = Expression.Parameter(typeof(BigInteger));
            var dividerArgument = Expression.Constant(BigInteger.Parse(divider));
            var predicate = Expression.Equal(
                Expression.Modulo(item, dividerArgument),
                Expression.Constant((BigInteger)0));
            var trueRecipientConstant = Expression.Constant(int.Parse(trueRecipient));
            var falseRecipientConstant = Expression.Constant(int.Parse(falseRecipient));
            var result = Expression.Variable(typeof(int));
            var ifThenElse = Expression.IfThenElse(predicate,
                Expression.Assign(result, trueRecipientConstant),
                Expression.Assign(result, falseRecipientConstant));
            var body = Expression.Block(new[] { result }, ifThenElse, result);
            var lambda = Expression.Lambda<Func<BigInteger, int>>(body, new[] { item });

            return lambda.Compile();
        }
    }

    public class Simulation
    {
        private readonly IList<Monkey> _Monkeys;

        public Simulation(IList<Monkey> monkeys)
        {
            _Monkeys = monkeys;
        }

        public void Run(int rounds)
        {
            for (var i = 0; i < rounds; i++)
            {
                foreach (var monkey in _Monkeys)
                {
                    var throwDescriptions = monkey.ThrowItems();
                    foreach (var throwDescription in throwDescriptions)
                    {
                        _Monkeys[throwDescription.Monkey].Receive(throwDescription.Item);
                    }
                }
            }
        }

        public long GetMonkeyBusinessLevel()
        {
            return _Monkeys.Select(m => m.Inspections)
                .OrderByDescending(i => i)
                .Take(2)
                .Aggregate((result, next) => result * next);
        }
    }
}
