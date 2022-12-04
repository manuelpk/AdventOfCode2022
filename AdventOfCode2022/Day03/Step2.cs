using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day03
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day03/Step1Input.txt").ToList();

            var prioSum = 0;

            var groups = new List<List<string>>();

            while (input.Any())
            {
                groups.Add(new List<string>(input.Take(3).ToList()));

                input.RemoveRange(0, 3);
            }

            foreach (var g in groups)
            {
                var matchingChar = GetMatchingChar(g);

                if (matchingChar != ' ')
                {
                    prioSum += GetPriority(matchingChar);
                }
            }

            Console.WriteLine($"PrioSum: {prioSum}");
        }

        public char GetMatchingChar(List<string> input)
        {
            var firstDict = input[0].Distinct().ToDictionary(i => i, i => i);
            var secondDict = input[1].Distinct().ToDictionary(i => i, i => i);
            var thirdDict = input[2].Distinct().ToDictionary(i => i, i => i);

            foreach(var c in firstDict)
            {
                if(secondDict.ContainsKey(c.Key) && thirdDict.ContainsKey(c.Key))
                {
                    return c.Key;
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
