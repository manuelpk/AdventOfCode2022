using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day06
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllText("Day06/Step1Input.txt");

            for (int i = 0; i < input.Length; i++)
            {
                if (input.Substring(i).Take(14).Distinct().Count() == 14)
                {
                    Console.WriteLine($"Position: {i + 14}");
                    break;
                }
            }
        }
    }
}
