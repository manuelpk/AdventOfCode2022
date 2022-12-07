using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day07
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day07/Step1Input.txt");

            var tree = new List<TreeItem>();

            var root = new TreeItem { Label = "/", Parent = null, IsDirectory = true };
            tree.Add(root);

            TreeItem currentDir = root;

            foreach (var i in input)
            {
                var cmd = i.Split(" ");

                if (cmd[0] == "$" && cmd[1] == "cd")
                {
                    if (cmd[2] == "..")
                    {
                        currentDir = currentDir.Parent;
                    }
                    else if (cmd[2] == "/")
                    {
                        currentDir = tree.FirstOrDefault();
                    }
                    else if (cmd[1] == "cd")
                    {
                        if (currentDir.Children.Any(x => x.Label == cmd[2]))
                        {
                            currentDir = currentDir.Children.FirstOrDefault(x => x.Label == cmd[2]);
                        }
                        else
                        {
                            var newDir = new TreeItem() { Label = cmd[2], Parent = currentDir, IsDirectory = true };
                            currentDir.Children.Add(newDir);
                            currentDir = newDir;
                        }
                    }
                }
                else if ((cmd[0] == "$" && cmd[1] == "ls") || cmd[0] == "dir")
                {
                }
                else
                {
                    var file = new TreeItem()
                    {
                        Label = cmd[1],
                        FileSize = int.Parse(cmd[0]),
                        IsDirectory = false,
                        Parent = currentDir,
                    };

                    currentDir.Children.Add(file);
                }
            }

            var flattenedList = Flatten(tree);

            var totalUsed = tree.FirstOrDefault().GetTotalFileSize;

            var dir = flattenedList.Where(x => x.IsDirectory && (totalUsed - x.GetTotalFileSize) <= 40000000).OrderBy(x => x.GetTotalFileSize).FirstOrDefault();

            Console.WriteLine($"TotalFileSize: {dir.GetTotalFileSize}");
        }

        private IEnumerable<TreeItem> Flatten(IEnumerable<TreeItem> start)
        {
            while (start.Any())
            {
                foreach (var entry in start)
                {
                    yield return entry;
                }

                start = start.SelectMany(x => x.Children);
            }
        }

        public class TreeItem
        {
            public TreeItem()
            {
                FileSize = 0;
                Children = new List<TreeItem>();
            }

            public string Label { get; set; }

            public int FileSize { get; set; }

            public bool IsDirectory { get; set; }

            public TreeItem Parent { get; set; }

            public List<TreeItem> Children { get; set; }

            public int GetTotalFileSize
            {
                get
                {
                    if (!IsDirectory)
                    {
                        return FileSize;
                    }
                    else
                    {
                        return Children.Select(x => GetBla(x)).Sum();
                    }
                }
            }

            public int GetBla(TreeItem item)
            {
                if (item.IsDirectory)
                {
                    return item.Children.Select(x => GetBla(x)).Sum();
                }
                else
                {
                    return item.FileSize;
                }
            }
        }
    }
}
