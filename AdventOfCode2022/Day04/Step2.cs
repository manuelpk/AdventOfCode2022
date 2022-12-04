using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day04
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day04/Step1Input.txt");

            var overlappingRanges = 0;

            foreach (var i in input)
            {
                var first = i.Split(',')[0];
                var second = i.Split(',')[1];

                var firstRange = GetRange(first);
                var secondRange = GetRange(second);

                if (IsOverlapping(firstRange, secondRange))
                {
                    overlappingRanges++;
                }
            }

            Console.WriteLine($"OverlappingRanges: {overlappingRanges}");
        }

        private bool IsOverlapping(IEnumerable<int> firstRange, IEnumerable<int> secondRange)
        {
            if (firstRange.Any(x => secondRange.Contains(x)))
            {
                return true;
            }

            return false;
        }

        private IEnumerable<int> GetRange(string first)
        {
            var start = int.Parse(first.Split('-')[0]);
            var end = int.Parse(first.Split('-')[1]);

            return Enumerable.Range(start, end - start + 1);
        }
    }
}
