using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day12
{
    public class Step1
    {
        Dictionary<(int, int), int> allPoints = new Dictionary<(int, int), int>();
        Dictionary<(int, int), int> usedSteps = new Dictionary<(int, int), int>();
        //List<Route> routes = new List<Route>();

        public Step1()
        {
            var input = File.ReadAllLines("Day12/Step1Input.txt").Reverse().ToList();

            (int x, int y) startPosition = new(0, 0);
            (int x, int y) endPosition = new(0, 0);

            var rowIndex = 0;

            foreach (var i in input)
            {
                var colIndex = 0;

                foreach (var c in i)
                {
                    if (c == 'S')
                    {
                        startPosition = new(colIndex, rowIndex);
                    }

                    if (c == 'E')
                    {
                        endPosition = new(colIndex, rowIndex);
                    }

                    char current = c == 'S' ? 'a' : c == 'E' ? 'z' : c;

                    allPoints.Add((colIndex, rowIndex), c == 'S' ? 1 : c == 'E' ? 26 : char.ToUpper(current) - 64);

                    colIndex++;
                }

                rowIndex++;
            }

            var stepCount = 0;
            usedSteps.Add(startPosition, stepCount);

            var nextSteps = GetNextSteps(startPosition);

            while (true)
            {
                if (!nextSteps.Any())
                {
                    break;
                }

                if (nextSteps.Any(x => x == endPosition))
                {
                    stepCount++;
                    break;
                }

                stepCount++;

                var testCnt = nextSteps.RemoveAll(x => usedSteps.ContainsKey(x) && usedSteps[x] <= stepCount);

                foreach (var step in nextSteps.Distinct().ToList())
                {
                    usedSteps.Add(step, stepCount);

                    nextSteps.AddRange(GetNextSteps(step));
                }
            }

            Console.WriteLine($"StepCount: {stepCount}");
        }

        private List<(int x, int y)> GetNextSteps((int x, int y) currentPosition)
        {
            var possibleNextSteps = new List<(int x, int y)>();
            possibleNextSteps.Add((currentPosition.x - 1, currentPosition.y));
            possibleNextSteps.Add((currentPosition.x + 1, currentPosition.y));
            possibleNextSteps.Add((currentPosition.x, currentPosition.y - 1));
            possibleNextSteps.Add((currentPosition.x, currentPosition.y + 1));

            return possibleNextSteps.Where(x => allPoints.ContainsKey(x) && (allPoints[x] <= allPoints[currentPosition] + 1)).ToList();
        }
    }
}
