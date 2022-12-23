using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day21
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day21/Step1Input.txt");

            var resolvedCodes = new Dictionary<string, double>();
            var unresolvedCodes = new Dictionary<string, (string val1, string mathOperator, string val2)>();
            (string val1, string val2) rootOperation = (string.Empty, string.Empty);

            foreach (var i in input)
            {
                var key = i.Substring(0, 4);
                var value = i.Substring(6);

                if (key == "root")
                {
                    rootOperation = (value.Split(" ")[0], value.Split(" ")[2]);
                }

                if (key != "humn")
                {
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

            var index = 0;
            while (true)
            {
                var tmpResolvedCodes = resolvedCodes.ToDictionary(x => x.Key, x => x.Value);
                tmpResolvedCodes.Add("humn", index);

                var remainingUnresolvedCodes = unresolvedCodes.ToDictionary(x => x.Key, x => x.Value);

                while (remainingUnresolvedCodes.Any())
                {
                    if (remainingUnresolvedCodes.Any(x => tmpResolvedCodes.ContainsKey(x.Value.val1) && tmpResolvedCodes.ContainsKey(x.Value.val2)))
                    {
                        var solvableCodes = remainingUnresolvedCodes.Where(x => tmpResolvedCodes.ContainsKey(x.Value.val1) && tmpResolvedCodes.ContainsKey(x.Value.val2)).ToDictionary(x => x.Key, x => x.Value);

                        if (solvableCodes.ContainsKey("root"))
                        {
                            break;
                        }

                        foreach (var s in solvableCodes)
                        {
                            tmpResolvedCodes.Add(s.Key, Calc(tmpResolvedCodes[s.Value.val1], tmpResolvedCodes[s.Value.val2], s.Value.mathOperator));
                            remainingUnresolvedCodes.Remove(s.Key);
                        }
                    }
                }

                if (tmpResolvedCodes[rootOperation.val1] == tmpResolvedCodes[rootOperation.val2])
                {
                    break;
                }

                index++;

                if (index % 10000 == 0)
                {
                    Console.WriteLine("CurrentIndex: " + index);
                }
            }

            Console.WriteLine($"Index: {index}");
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
