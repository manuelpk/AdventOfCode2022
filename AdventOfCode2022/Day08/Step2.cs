using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day08
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day08/Step1Input.txt");

            var visibleTrees = input.Count() * 2 + (input[0].Length - 2) * 2;

            var score = 0;

            var rowIdx = 0;
            foreach (var i in input)
            {
                var colIdx = 0;
                foreach (var c in i)
                {
                    var currentTree = int.Parse(c.ToString());

                    int countBefore = 0;
                    foreach (var t in i.Substring(0, colIdx).Select(x => int.Parse(x.ToString())).Reverse())
                    {
                        countBefore++;

                        if(t >= currentTree)
                        {
                            break;
                        }
                    }

                    int countAfter = 0;
                    foreach (var t in i.Substring(colIdx + 1).Select(x => int.Parse(x.ToString())))
                    {
                        countAfter++;

                        if (t >= currentTree)
                        {
                            break;
                        }
                    }

                    int countAbove = 0;
                    foreach (var t in input.Take(rowIdx).Select(x => int.Parse(x.ElementAt(colIdx).ToString())).Reverse())
                    {
                        countAbove++;

                        if (t >= currentTree)
                        {
                            break;
                        }
                    }

                    int countUnder = 0;
                    foreach (var t in input.TakeLast(input.Count() - (rowIdx + 1)).Select(x => int.Parse(x.ElementAt(colIdx).ToString())))
                    {
                        countUnder++;

                        if (t >= currentTree)
                        {
                            break;
                        }
                    }

                    var tmpScore = countBefore * countAfter * countAbove * countUnder;

                    if (tmpScore > score)
                    {
                        score = tmpScore;
                    }

                    colIdx++;
                }

                rowIdx++;
            }

            Console.WriteLine($"Score: {score}");
        }
    }
}
