namespace AdventOfCode2022.Day12
{
    public class Day12 : IDay
    {
        public object Part1(string input)
        {
            var map = input.GetLines()
                .Select((l, y) => l.Select((c, x) => new Node(x, y, c)).ToArray())
                .ToArray();
            var endNode = BreadthFirstSearch(map,
                isStart: node => node.IsStart,
                isEnd: node => node.IsEnd,
                isNext: (node, nextNode) => nextNode.Height == node.Height || nextNode.Height == node.Height + 1 || nextNode.Height < node.Height);

            return endNode!.GetPathLength();
        }

        public object Part2(string input)
        {
            var map = input.GetLines()
                .Select((l, y) => l.Select((c, x) => new Node(x, y, c)).ToArray())
                .ToArray();
            var endNode = BreadthFirstSearch(map,
                isStart: node => node.IsEnd,
                isEnd: node => node.Height == 'a',
                isNext: (node, nextNode) => nextNode.Height == node.Height || nextNode.Height == node.Height - 1 || nextNode.Height > node.Height);

            return endNode!.GetPathLength();
        }

        public static Node? BreadthFirstSearch(
            Node[][] map,
            Func<Node, bool> isStart,
            Func<Node, bool> isEnd,
            Func<Node, Node, bool> isNext)
        {
            var queue = new Queue<Node>();
            var startNode = map.SelectMany(n => n)
                .Single(isStart);
            startNode.IsVisited = true;
            queue.Enqueue(startNode);
            while (queue.TryDequeue(out var node))
            {
                if (isEnd(node))
                {
                    return node;
                }
                var nextNodes = GetNextNodes(node, map, isNext)
                    .Where(n => !n.IsVisited);
                foreach (var nextNode in nextNodes)
                {
                    if (!nextNode.IsVisited)
                    {
                        nextNode.IsVisited = true;
                        nextNode.Previous = node;
                        queue.Enqueue(nextNode);
                    }
                }
            }

            return null;
        }

        public static IEnumerable<Node> GetNextNodes(Node node, Node[][] map, Func<Node, Node, bool> isNext)
        {
            var x = node.X;
            var y = node.Y;
            if (y < map.Length - 1 && isNext(node, map[y + 1][x]))
            {
                yield return map[y + 1][x];
            }
            if (y > 0 && isNext(node, map[y - 1][x]))
            {
                yield return map[y - 1][x];
            }
            if (x < map[y].Length - 1 && isNext(node, map[y][x + 1]))
            {
                yield return map[y][x + 1];
            }
            if (x > 0 && isNext(node, map[y][x - 1]))
            {
                yield return map[y][x - 1];
            }
        }
    }

    public class Node
    {
        public int X { get; }

        public int Y { get; }

        public char Height { get; }

        public bool IsStart { get; }

        public bool IsEnd { get; }

        public bool IsVisited { get; set; }

        public Node? Previous { get; set; }

        public Node(int x, int y, char height)
        {
            switch (height)
            {
                case 'S':
                    Height = 'a';
                    IsStart = true;
                    break;
                case 'E':
                    Height = 'z';
                    IsEnd = true;
                    break;
                default:
                    Height = height;
                    break;
            }
            X = x;
            Y = y;
        }

        public int GetPathLength()
        {
            var pathLength = 0;
            var node = Previous;
            while (node != null)
            {
                pathLength++;
                node = node.Previous;
            }

            return pathLength;
        }
    }
}
