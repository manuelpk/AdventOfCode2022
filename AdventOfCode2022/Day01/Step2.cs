using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day01
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day01/Step1Input.txt");

            var AllTotals = new List<int>();

            var total = 0;

            foreach (var i in input)
            {
                if (string.IsNullOrWhiteSpace(i))
                {
                    AllTotals.Add(total);

                    total = 0;
                }
                else
                {
                    total += int.Parse(i);
                }
            }

            var result = AllTotals.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine($"Result: {result}");
        }
    }
}
