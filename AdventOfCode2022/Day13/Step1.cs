using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day13
{
    public class Step1
    {
        public Step1()
        {
            //var input = File.ReadAllLines("Day13/SampleInput.txt");

            var input = File.ReadAllText("Day13/SampleInput.txt");

            var pairs = input.Split(Environment.NewLine + Environment.NewLine);

            var rightOrderCount = 0;

            foreach (var p in pairs)
            {
            }

            Console.WriteLine($"RightOrderCount: {rightOrderCount}");
        }
    }
}
