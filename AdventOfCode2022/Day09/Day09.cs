namespace AdventOfCode2022.Day09
{
    public class Day09 : IDay
    {
        public object Part1(string input)
        {
            var simulation = new Simulation();
            simulation.Run(input.GetLines());

            return simulation.GetUniqueTailPositionsCount();
        }

        public object Part2(string input)
        {
            throw new NotImplementedException();
        }

        public class Simulation
        {
            private readonly Dictionary<string, Func<(int X, int Y), (int X, int Y)>> _HeadStepFactories = new()
            {
                ["U"] = pos => (pos.X, pos.Y + 1),
                ["D"] = pos => (pos.X, pos.Y - 1),
                ["L"] = pos => (pos.X - 1, pos.Y),
                ["R"] = pos => (pos.X + 1, pos.Y),
            };

            private readonly List<(int X, int Y)> _TailPath = new() { (0, 0) };

            private (int X, int Y) _Head = (0, 0);

            private (int X, int Y) _Tail = (0, 0);

            public void Run(IEnumerable<string> commands)
            {
                foreach (var command in commands)
                {
                    var tokens = command.Split(' ');
                    var steps = int.Parse(tokens[1]);
                    UpdatePositions(steps, _HeadStepFactories[tokens[0]]);
                }
            }

            public int GetUniqueTailPositionsCount()
            {
                return _TailPath.Distinct().Count();
            }

            private void UpdatePositions(int steps, Func<(int X, int Y), (int X, int Y)> headStepFactory)
            {
                for (var i = 0; i < steps; i++)
                {
                    _Head = headStepFactory(_Head);
                    if (_Head == (_Tail.X + 1, _Tail.Y + 1) ||
                        _Head == (_Tail.X + 1, _Tail.Y) ||
                        _Head == (_Tail.X + 1, _Tail.Y - 1) ||
                        _Head == (_Tail.X, _Tail.Y + 1) ||
                        _Head == _Tail ||
                        _Head == (_Tail.X, _Tail.Y - 1) ||
                        _Head == (_Tail.X - 1, _Tail.Y + 1) ||
                        _Head == (_Tail.X - 1, _Tail.Y) ||
                        _Head == (_Tail.X - 1, _Tail.Y - 1))
                    {
                        continue;
                    }
                    MoveTail();
                    _TailPath.Add(_Tail);
                }
            }

            private void MoveTail()
            {
                if (_Tail.X == _Head.X || _Tail.Y == _Head.Y)
                {
                    _Tail = ((_Head.X + _Tail.X) / 2, (_Head.Y + _Tail.Y) / 2);
                }
                else if (_Tail.X > _Head.X && _Tail.Y < _Head.Y)
                {
                    _Tail = (_Tail.X - 1, _Tail.Y + 1);
                }
                else if (_Tail.X < _Head.X && _Tail.Y < _Head.Y)
                {
                    _Tail = (_Tail.X + 1, _Tail.Y + 1);
                }
                else if (_Tail.X < _Head.X && _Tail.Y > _Head.Y)
                {
                    _Tail = (_Tail.X + 1, _Tail.Y - 1);
                }
                else if (_Tail.X > _Head.X && _Tail.Y > _Head.Y)
                {
                    _Tail = (_Tail.X - 1, _Tail.Y - 1);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
