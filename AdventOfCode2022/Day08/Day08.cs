namespace AdventOfCode2022.Day08
{
    public class Day08 : IDay
    {
        public object Part1(string input)
        {
            var grid = input.GetLines()
                .Select(l => l.Select(c => c - 48).ToArray())
                .ToArray();
            var visibleCount = 0;
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    if (IsVisibleFromNorth(x, y, grid) ||
                        IsVisibleFromSouth(x, y, grid) ||
                        IsVisibleFromWest(x, y, grid) ||
                        IsVisibleFromEast(x, y, grid))
                    {
                        visibleCount++;
                    }
                }
            }

            return visibleCount;
        }

        public object Part2(string input)
        {
            var grid = input.GetLines()
                .Select(l => l.Select(c => c - 48).ToArray())
                .ToArray();
            var scenicScores = new List<int>();
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    var scenicScore = GetVisibleFromNorthCount(x, y, grid) * GetVisibleFromSouthCount(x, y, grid) *
                        GetVisibleFromWestCount(x, y, grid) * GetVisibleFromEastCount(x, y, grid);
                    scenicScores.Add(scenicScore);
                }
            }

            return scenicScores.Max();
        }

        private static bool IsVisibleFromNorth(int x, int y, int[][] grid)
        {
            for (var currentY = y - 1; currentY >= 0; currentY--)
            {
                if (grid[y][x] <= grid[currentY][x])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsVisibleFromSouth(int x, int y, int[][] grid)
        {
            for (var currentY = y + 1; currentY < grid.Length; currentY++)
            {
                if (grid[y][x] <= grid[currentY][x])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsVisibleFromWest(int x, int y, int[][] grid)
        {
            for (var currentX = x - 1; currentX >= 0; currentX--)
            {
                if (grid[y][x] <= grid[y][currentX])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsVisibleFromEast(int x, int y, int[][] grid)
        {
            for (var currentX = x + 1; currentX < grid[y].Length; currentX++)
            {
                if (grid[y][x] <= grid[y][currentX])
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetVisibleFromNorthCount(int x, int y, int[][] grid)
        {
            var visibleCount = 0;
            for (var currentY = y - 1; currentY >= 0; currentY--)
            {
                visibleCount++;
                if (grid[y][x] <= grid[currentY][x])
                {
                    break;
                }
            }

            return visibleCount;
        }

        private static int GetVisibleFromSouthCount(int x, int y, int[][] grid)
        {
            var visibleCount = 0;
            for (var currentY = y + 1; currentY < grid.Length; currentY++)
            {
                visibleCount++;
                if (grid[y][x] <= grid[currentY][x])
                {
                    break;
                }
            }

            return visibleCount;
        }

        private static int GetVisibleFromWestCount(int x, int y, int[][] grid)
        {
            var visibleCount = 0;
            for (var currentX = x - 1; currentX >= 0; currentX--)
            {
                visibleCount++;
                if (grid[y][x] <= grid[y][currentX])
                {
                    break;
                }
            }

            return visibleCount;
        }

        private static int GetVisibleFromEastCount(int x, int y, int[][] grid)
        {
            var visibleCount = 0;
            for (var currentX = x + 1; currentX < grid[y].Length; currentX++)
            {
                visibleCount++;
                if (grid[y][x] <= grid[y][currentX])
                {
                    break;
                }
            }

            return visibleCount;
        }
    }
}
