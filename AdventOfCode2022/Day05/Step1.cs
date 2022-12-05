using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day05
{
    public class Step1
    {
        private Dictionary<int, List<string>> _stacks;

        public Step1()
        {
            var input = File.ReadAllLines("Day05/Step1Input2.txt");

            InitializeStacks();

            foreach (var i in input)
            {
                var procedure = i.Split(" ").Where(x => int.TryParse(x, out _)).Select(x => int.Parse(x)).ToList();

                var cratesCount = procedure[0];
                var from = procedure[1];
                var to = procedure[2];

                var crates = _stacks[from].TakeLast(cratesCount).Reverse().ToList();

                _stacks[from].RemoveRange(_stacks[from].Count - cratesCount, cratesCount);
                _stacks[to].AddRange(crates);
            }

            var result = string.Join("", _stacks.OrderBy(x => x.Key).SelectMany(x => x.Value.Last()));

            Console.WriteLine($"Result: {result}");
        }

        private void InitializeStacks()
        {
            _stacks = new Dictionary<int, List<string>>();

            _stacks.Add(1, new List<string> { "Z", "T", "F", "R", "W", "J", "G" });
            _stacks.Add(2, new List<string> { "G", "W", "M" });
            _stacks.Add(3, new List<string> { "J", "N", "H", "G" });
            _stacks.Add(4, new List<string> { "J", "R", "C", "N", "W" });
            _stacks.Add(5, new List<string> { "W", "F", "S", "B", "G", "Q", "V", "M" });
            _stacks.Add(6, new List<string> { "S", "R", "T", "D", "V", "W", "C" });
            _stacks.Add(7, new List<string> { "H", "B", "N", "C", "D", "Z", "G", "V" });
            _stacks.Add(8, new List<string> { "S", "J", "N", "M", "G", "C" });
            _stacks.Add(9, new List<string> { "G", "P", "N", "W", "C", "J", "D", "L" });
        }
    }
}
