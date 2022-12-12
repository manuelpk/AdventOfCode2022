using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day09
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day09/Step1Input.txt");

            (int x, int y) headPosition = (0, 0);
            (int x, int y) tailPosition = (0, 0);
            Dictionary<(int, int), int> visitedPositions = new Dictionary<(int, int), int>();

            foreach (var i in input)
            {
                var direction = i.Split(" ")[0];
                var steps = int.Parse(i.Split(" ")[1]);

                for (int p = 0; p < steps; p++)
                {
                    switch (direction)
                    {
                        case "L":
                            headPosition = (headPosition.x - 1, headPosition.y);

                            if (Math.Abs(tailPosition.x - headPosition.x) > 1)
                            {
                                tailPosition = (headPosition.x + 1, headPosition.y);
                            }
                            break;
                        case "R":
                            headPosition = (headPosition.x + 1, headPosition.y);

                            if (Math.Abs(tailPosition.x - headPosition.x) > 1)
                            {
                                tailPosition = (headPosition.x - 1, headPosition.y);
                            }
                            break;
                        case "U":
                            headPosition = (headPosition.x, headPosition.y + 1);

                            if (Math.Abs(tailPosition.y - headPosition.y) > 1)
                            {
                                tailPosition = (headPosition.x, headPosition.y - 1);
                            }
                            break;
                        case "D":
                            headPosition = (headPosition.x, headPosition.y - 1);

                            if (Math.Abs(tailPosition.y - headPosition.y) > 1)
                            {
                                tailPosition = (headPosition.x, headPosition.y + 1);
                            }
                            break;
                        default:
                            break;
                    }

                    if (visitedPositions.ContainsKey(tailPosition))
                    {
                        visitedPositions[tailPosition]++;
                    }
                    else
                    {
                        visitedPositions.Add(tailPosition, 1);
                    }
                }


            }

            Console.WriteLine($"VisitedPositions: {visitedPositions.Count}");
        }
    }
}
