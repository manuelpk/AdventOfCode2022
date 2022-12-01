using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day01
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day01/Step1Input.txt");

            var mostTotal = 0;

            var total = 0;

            foreach (var i in input)
            {
                if (string.IsNullOrWhiteSpace(i))
                {
                    if (total > mostTotal)
                    {
                        mostTotal = total;
                    }

                    total = 0;
                }
                else
                {
                    total += int.Parse(i);
                }
            }

            Console.WriteLine($"MostTotal: {mostTotal}");
        }
    }
}
