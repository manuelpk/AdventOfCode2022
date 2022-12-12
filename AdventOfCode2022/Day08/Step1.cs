using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day08
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day08/Step1Input.txt");

            var visibleTrees = input.Count() * 2 + (input[0].Length - 2) * 2;

            var rowIdx = 0;
            foreach (var i in input)
            {
                if (rowIdx == 0 || rowIdx == (input.Count() - 1))
                {
                    rowIdx++;
                    continue;
                }

                var colIdx = 0;
                foreach (var c in i)
                {
                    if (colIdx == 0 || colIdx == (i.Length - 1))
                    {
                        colIdx++;
                        continue;
                    }

                    var currentTree = int.Parse(c.ToString());

                    var colTreesBefore = i.Substring(0, colIdx).Select(x => int.Parse(x.ToString()));
                    var colTreesAfter = i.Substring(colIdx + 1).Select(x => int.Parse(x.ToString()));

                    var rowTreesAbove = input.Take(rowIdx).Select(x => int.Parse(x.ElementAt(colIdx).ToString())).ToList();
                    var rowTreesUnder = input.TakeLast(input.Count() - (rowIdx + 1)).Select(x => int.Parse(x.ElementAt(colIdx).ToString())).ToList();

                    if (colTreesBefore.All(x => x < currentTree)
                        || colTreesAfter.All(x => x < currentTree)
                        || rowTreesAbove.All(x => x < currentTree)
                        || rowTreesUnder.All(x => x < currentTree))
                    {
                        visibleTrees++;
                    }

                    colIdx++;
                }

                rowIdx++;
            }

            Console.WriteLine($"VisibleTrees: {visibleTrees}");
        }
    }
}
