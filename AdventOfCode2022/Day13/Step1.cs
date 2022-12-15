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
                var leftData = p.Split(Environment.NewLine)[0];
                var rightData = p.Split(Environment.NewLine)[1];

                var cleanedLeftData = leftData.Replace("[", "").Replace("]", "").Split(",");
                var cleanedRightData = rightData.Replace("[", "").Replace("]", "").Split(",");

                if (!cleanedLeftData.Any() && cleanedRightData.Any())
                {
                    var leftSquareBrackets = leftData.Count(x => x == '[');

                    var rightSquareBrackets = leftData.Count(x => x == '[');

                    if (leftSquareBrackets <= rightSquareBrackets)
                    {
                        rightOrderCount++;
                    }
                }
                else
                {
                    var rightOrder = true;

                    for (int idx = 0; idx < cleanedLeftData.Length; idx++)
                    {
                        if (idx >= cleanedRightData.Length)
                        {
                            rightOrder = false;
                            break;
                        }

                        if (string.IsNullOrEmpty(cleanedLeftData[idx]) && string.IsNullOrEmpty(cleanedRightData[idx]))
                        {
                            break;
                        }

                        if (string.IsNullOrEmpty(cleanedLeftData[idx]) && !string.IsNullOrEmpty(cleanedRightData[idx]))
                        {
                            rightOrder = false;
                            break;
                        }

                        if (int.Parse(cleanedLeftData[idx]) > int.Parse(cleanedRightData[idx]))
                        {
                            rightOrder = false;
                            break;
                        }
                    }

                    if (rightOrder)
                    {
                        rightOrderCount++;
                    }
                }
            }

            Console.WriteLine($"RightOrderCount: {rightOrderCount}");
        }
    }
}
