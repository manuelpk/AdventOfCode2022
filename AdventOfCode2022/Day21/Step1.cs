using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day21
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day21/Step1Input.txt");

            var resolvedCodes = new Dictionary<string, double>();
            var unresolvedCodes = new Dictionary<string, (string val1, string mathOperator, string val2)>();

            foreach (var i in input)
            {
                var key = i.Substring(0, 4);
                var value = i.Substring(6);

                if (double.TryParse(value, out double parsedValue))
                {
                    resolvedCodes.Add(key, parsedValue);
                }
                else
                {
                    var splitted = value.Split(" ");

                    unresolvedCodes.Add(key, (splitted[0], splitted[1], splitted[2]));
                }
            }

            while (unresolvedCodes.Any())
            {
                if (unresolvedCodes.Any(x => resolvedCodes.ContainsKey(x.Value.val1) && resolvedCodes.ContainsKey(x.Value.val2)))
                {
                    var solvableCodes = unresolvedCodes.Where(x => resolvedCodes.ContainsKey(x.Value.val1) && resolvedCodes.ContainsKey(x.Value.val2));

                    foreach (var s in solvableCodes)
                    {
                        resolvedCodes.Add(s.Key, Calc(resolvedCodes[s.Value.val1], resolvedCodes[s.Value.val2], s.Value.mathOperator));
                        unresolvedCodes.Remove(s.Key);
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"Root: {resolvedCodes["root"]}");
        }

        private double Calc(double val1, double val2, string mathOperator)
        {
            switch (mathOperator)
            {
                case "+":
                    return val1 + val2;
                case "-":
                    return val1 - val2;
                case "*":
                    return val1 * val2;
                case "/":
                    return val1 / val2;
                default:
                    return 0;
            }
        }
    }
}
