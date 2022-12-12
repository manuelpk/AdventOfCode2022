using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day09
{
    public class Step2
    {
        public Step2()
        {
            var input = File.ReadAllLines("Day09/SampleInput.txt");

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

                            for (int index = 0; index < tailPositions.Count; index++)
                            {
                                if (index == 0)
                                {
                                    if (Math.Abs(tailPositions[index].x - headPosition.x) > 1)
                                    {
                                        tailPositions[index] = (headPosition.x + 1, headPosition.y);
                                    }
                                }
                                else
                                {
                                    if (Math.Abs(tailPositions[index].x - tailPositions[index -1].x) > 1)
                                    {
                                        tailPositions[index] = (tailPositions[index -1].x + 1, tailPositions[index - 1].y);
                                    }
                                }
                            }

                            break;
                        case "R":
                            headPosition = (headPosition.x + 1, headPosition.y);

                            for (int index = 0; index < tailPositions.Count; index++)
                            {
                                if (index == 0)
                                {
                                    if (Math.Abs(tailPositions[index].x - headPosition.x) > 1)
                                    {
                                        tailPositions[index] = (headPosition.x - 1, headPosition.y);
                                    }
                                }
                                else
                                {
                                    if (Math.Abs(tailPositions[index].x - tailPositions[index - 1].x) > 1)
                                    {
                                        tailPositions[index] = (tailPositions[index - 1].x - 1, tailPositions[index - 1].y);
                                    }
                                }
                            }

                            break;
                        case "U":
                            headPosition = (headPosition.x, headPosition.y + 1);

                            for (int index = 0; index < tailPositions.Count; index++)
                            {
                                if (index == 0)
                                {
                                    if (Math.Abs(tailPositions[index].y - headPosition.y) > 1)
                                    {
                                        tailPositions[index] = (headPosition.x, headPosition.y -1);
                                    }
                                }
                                else
                                {
                                    if (Math.Abs(tailPositions[index].y - tailPositions[index - 1].y) > 1)
                                    {
                                        tailPositions[index] = (tailPositions[index - 1].x, tailPositions[index - 1].y - 1);
                                    }
                                }
                            }

                            break;
                        case "D":
                            headPosition = (headPosition.x, headPosition.y - 1);

                            for (int index = 0; index < tailPositions.Count; index++)
                            {
                                if (index == 0)
                                {
                                    if (Math.Abs(tailPositions[index].y - headPosition.y) > 1)
                                    {
                                        tailPositions[index] = (headPosition.x, headPosition.y - 1);
                                    }
                                }
                                else
                                {
                                    if (Math.Abs(tailPositions[index].y - tailPositions[index - 1].y) > 1)
                                    {
                                        tailPositions[index] = (tailPositions[index - 1].x, tailPositions[index - 1].y + 1);
                                    }
                                }
                            }
                            break;
                        default:
                            break;
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
