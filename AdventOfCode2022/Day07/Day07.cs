namespace AdventOfCode2022.Day07
{
    public class Day07 : IDay
    {
        public object Part1(string input)
        {
            var root = GetRootDirectory(input.GetLines());

            return root.GetDirectoriesRecursive()
                .Where(d => d.Size <= 100_000)
                .Sum(d => d.Size);
        }

        public object Part2(string input)
        {
            var root = GetRootDirectory(input.GetLines());
            var minNeededSpace = 30_000_000 - (70_000_000 - root.Size);

            return root.GetDirectoriesRecursive()
                .Where(d => d.Size >= minNeededSpace)
                .Min(d => d.Size);
        }

        private static Directory GetRootDirectory(IEnumerable<string> lines)
        {
            var rootDirectory = new Directory("/", null);
            Directory? currentDirectory = null;
            foreach (var line in lines)
            {
                if (line == "$ cd /")
                {
                    currentDirectory = rootDirectory;
                }
                else if (line == "$ cd ..")
                {
                    currentDirectory = currentDirectory?.ParentDirectory;
                }
                else if (line.StartsWith("$ cd "))
                {
                    currentDirectory = currentDirectory?.ChildDirectories.First(d => d.Name == line[5..]);
                }
                else if (line != "$ ls")
                {
                    var tokens = line.Split(' ');
                    if (tokens[0] == "dir")
                    {
                        currentDirectory?.ChildDirectories.Add(new Directory(tokens[1], currentDirectory));
                    }
                    else
                    {
                        currentDirectory?.Files.Add(new File(tokens[1], int.Parse(tokens[0])));
                    }
                }
            }

            return rootDirectory;
        }
    }

    public class Directory
    {
        public string Name { get; }

        public Directory? ParentDirectory { get; }

        public List<Directory> ChildDirectories { get; } = new();

        public List<File> Files { get; } = new();

        public int Size => ChildDirectories.Sum(d => d.Size) + Files.Sum(f => f.Size);

        public Directory(string name, Directory? parentDirectory)
        {
            Name = name;
            ParentDirectory = parentDirectory;
        }

        public IEnumerable<Directory> GetDirectoriesRecursive()
        {
            yield return this;

            var childDirectories = ChildDirectories.SelectMany(d => d.GetDirectoriesRecursive());
            foreach (var childDirectory in childDirectories)
            {
                yield return childDirectory;
            }
        }
    }

    public class File
    {
        public string Name { get; }

        public int Size { get; }

        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
