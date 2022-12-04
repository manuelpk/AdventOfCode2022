using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day04
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day04/Step1Input.txt");

            var fullyContainedRanges = 0;

            foreach (var i in input)
            {
                var first = i.Split(',')[0];
                var second = i.Split(',')[1];

                var firstRange = GetRange(first);
                var secondRange = GetRange(second);

                if (ContainsRange(firstRange, secondRange))
                {
                    fullyContainedRanges++;
                }
            }

            Console.WriteLine($"FullyContainedRanges: {fullyContainedRanges}");
        }

        private bool ContainsRange(IEnumerable<int> firstRange, IEnumerable<int> secondRange)
        {
            var firstIntersect = firstRange.Intersect(secondRange);

            if (secondRange.SequenceEqual(firstIntersect))
            {
                return true;
            }

            var secondIntersect = secondRange.Intersect(firstRange);

            if (firstRange.SequenceEqual(secondIntersect))
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
