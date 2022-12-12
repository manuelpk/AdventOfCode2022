using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day10
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day10/Step1Input.txt");

            int x = 1;
            int cycles = 0;
            int total = 0;

            foreach (var i in input)
            {
                cycles++;

                total = total + CheckCycles(cycles, x);

                if (i.Split(" ")[0] == "addx")
                {
                    cycles++;

                    total = total + CheckCycles(cycles, x);

                    x = x + int.Parse(i.Split(" ")[1]);
                }
            }

            Console.WriteLine($"Total: {total}");
        }

        private int CheckCycles(int cycles, int x)
        {
            var checks = new List<int> { 20, 60, 100, 140, 180, 220 };

            if (checks.Contains(cycles))
            {
                return cycles * x;
            }
            else
            {
                return 0;
            }
        }
    }
}
