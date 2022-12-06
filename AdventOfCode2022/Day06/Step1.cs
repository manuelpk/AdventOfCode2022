using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day06
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllText("Day06/Step1Input.txt");

            for (int i = 0; i < input.Length; i++)
            {
                if (input.Substring(i).Take(4).Distinct().Count() == 4)
                {
                    Console.WriteLine($"Position: {i + 4}");
                    break;
                }
            }
        }
    }
}
