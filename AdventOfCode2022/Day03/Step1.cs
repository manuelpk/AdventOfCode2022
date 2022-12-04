using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day03
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day03/Step1Input.txt");

            var prioSum = 0;

            foreach (var i in input)
            {
                var half = (i.Count() / 2);

                var first = i.Substring(0, half);
                var second = i.Substring(half);

                var matchingChar = GetMatchingChar(first, second);

                if (matchingChar != ' ')
                {
                    prioSum += GetPriority(matchingChar);
                }
            }

            Console.WriteLine($"PrioSum: {prioSum}");
        }

        public char GetMatchingChar(string first, string second)
        {
            foreach (var c in first)
            {
                if (second.Contains(c))
                {
                    return c;
                }
            }

            return ' ';
        }

        public int GetPriority(char matchingChar)
        {            
            var alphabet = Enumerable.Range('a', 26).Select(x => (char)x).ToList();

            if (char.IsUpper(matchingChar))
            {
                var lowerCaseChar = matchingChar.ToString().ToLower();
                var index = alphabet.IndexOf(lowerCaseChar[0]);

                return (index + 1) + 26;
            }
            else
            {
                return alphabet.IndexOf(matchingChar) + 1;
            }

        }
    }
}
