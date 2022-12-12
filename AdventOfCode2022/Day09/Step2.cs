using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day09
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day09/Step1Input.txt");

            (int x, int y) headPosition = (0, 0);
            List<(int x, int y)> tailPositions = new List<(int x, int y)>();
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));
            tailPositions.Add(new(0, 0));

            Dictionary<(int, int), int> visitedPositions = new Dictionary<(int, int), int>();

            foreach (var i in input)
            {
                var direction = i.Split(" ")[0];
                var steps = int.Parse(i.Split(" ")[1]);

                for (int s = 0; s < steps; s++)
                {
                    switch (direction)
                    {
                        case "L":
                            headPosition = (headPosition.x - 1, headPosition.y);

                            break;
                        case "R":
                            headPosition = (headPosition.x + 1, headPosition.y);

                            break;
                        case "U":
                            headPosition = (headPosition.x, headPosition.y + 1);

                            break;
                        case "D":
                            headPosition = (headPosition.x, headPosition.y - 1);

                            break;
                        default:
                            break;
                    }

                    for (int index = 0; index < tailPositions.Count; index++)
                    {
                        var prevPosition = index == 0 ? headPosition : tailPositions[index - 1];

                        if (Math.Abs(tailPositions[index].x - prevPosition.x) > 1 || Math.Abs(tailPositions[index].y - prevPosition.y) > 1)
                        {
                            if (tailPositions[index].x < prevPosition.x)
                            {
                                tailPositions[index] = (tailPositions[index].x + 1, tailPositions[index].y);
                            }
                            else if (tailPositions[index].x > prevPosition.x)
                            {
                                tailPositions[index] = (tailPositions[index].x - 1, tailPositions[index].y);
                            }

                            if (tailPositions[index].y < prevPosition.y)
                            {
                                tailPositions[index] = (tailPositions[index].x, tailPositions[index].y + 1);
                            }
                            else if (tailPositions[index].y > prevPosition.y)
                            {
                                tailPositions[index] = (tailPositions[index].x, tailPositions[index].y - 1);
                            }
                        }
                    }

                    if (visitedPositions.ContainsKey(tailPositions[8]))
                    {
                        visitedPositions[tailPositions[8]]++;
                    }
                    else
                    {
                        visitedPositions.Add(tailPositions[8], 1);
                    }
                }
            }

            Console.WriteLine($"VisitedPositions: {visitedPositions.Count}");
        }
    }
}
