using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day12
{
    public class Step1
    {
        Dictionary<(int, int), int> allPoints = new Dictionary<(int, int), int>();
        List<Route> routes = new List<Route>();
        int maxX;
        int maxY;

        public Step1()
        {
            var input = File.ReadAllLines("Day12/SampleInput.txt").Reverse().ToList();

            var startRow = input.First(x => x.Contains("S"));
            var startRowIndex = input.ToList().IndexOf(startRow);

            var startColumnIndex = startRow.IndexOf("S");

            (int x, int y) startPosition = new(startColumnIndex, startRowIndex);

            var endRow = input.First(x => x.Contains("E"));
            var endRowIndex = input.ToList().IndexOf(endRow);

            var endColumnIndex = endRow.IndexOf("E");

            (int x, int y) endPosition = new(endColumnIndex, endRowIndex);

            //char.ToUpper(alphabet[0]) - 64

            var rowIndex = 0;

            foreach (var i in input)
            {
                var colIndex = 0;

                foreach (var c in i)
                {
                    char current = c == 'S' ? 'a' : c == 'E' ? 'z' : c;

                    var charValue = c == 'S' ? 0 : c == 'E' ? 27 : char.ToUpper(current) - 64;
                    allPoints.Add((colIndex, rowIndex), charValue);

                    colIndex++;
                }

                rowIndex++;
            }

            maxX = allPoints.Max(x => x.Key.Item1);
            maxY = allPoints.Max(x => x.Key.Item2);

            var rootRoute = new Route() { Steps = 0, StartPosition = startPosition };
            var neighbors = GetNeighbors(startPosition, rootRoute.UsedSteps);
            var nextSteps = neighbors.Where(x => x.value == allPoints[startPosition] || x.value == allPoints[startPosition] + 1).ToList();

            GoNextSteps(rootRoute, nextSteps, startPosition);

            routes.Add(rootRoute);

            var bla = routes.Any(x => x.ReachedTarget);
            ////Console.WriteLine($"MostTotal: {mostTotal}");
        }

        private void GoNextSteps(Route currentRoute, List<(int x, int y, int value)> nextSteps, (int x, int y) currentPosition)
        {
            if(currentRoute.Steps > 31) // test
            {
            }

            if (nextSteps.Any(x => x.value == 27))
            {
                currentRoute.ReachedTarget = true;
                return;
            }

            if (nextSteps.Count == 0)
            {
                return;
            }
            else if (nextSteps.Count == 1)
            {
                currentRoute.UsedSteps.Add(new(currentPosition.x, currentPosition.y));

                currentRoute.Steps++;
                currentPosition = new(nextSteps[0].x, nextSteps[0].y);

                var neighbors = GetNeighbors(currentPosition, currentRoute.UsedSteps);
                var newNextSteps = neighbors.Where(x => x.value == allPoints[currentPosition] || x.value == allPoints[currentPosition] + 1).ToList();

                GoNextSteps(currentRoute, newNextSteps, currentPosition);
            }
            else
            {
                currentRoute.Steps++;

                foreach (var step in nextSteps)
                {
                    currentRoute.UsedSteps.Add(new(currentPosition.x, currentPosition.y));

                    currentPosition = new(step.x, step.y);

                    var neighbors = GetNeighbors(currentPosition, currentRoute.UsedSteps);
                    var newNextSteps = neighbors.Where(x => x.value == allPoints[currentPosition] || x.value == allPoints[currentPosition] + 1).ToList();

                    var newRoute = new Route() { Steps = currentRoute.Steps, StartPosition = currentPosition, UsedSteps = currentRoute.UsedSteps };

                    GoNextSteps(newRoute, newNextSteps, currentPosition);

                    routes.Add(newRoute);
                }
            }
        }

        private List<(int x, int y, int value)> GetNeighbors((int x, int y) currentPosition, List<(int x, int y)> usedSteps)
        {
            var neighbors = new List<(int x, int y, int value)>();

            if (currentPosition.x - 1 > 0)
            {
                neighbors.Add((currentPosition.x - 1, currentPosition.y, allPoints[(currentPosition.x - 1, currentPosition.y)]));
            }

            if (currentPosition.x + 1 <= maxX)
            {
                neighbors.Add((currentPosition.x + 1, currentPosition.y, allPoints[(currentPosition.x + 1, currentPosition.y)]));
            }

            if (currentPosition.y - 1 > 0)
            {
                neighbors.Add((currentPosition.x, currentPosition.y - 1, allPoints[(currentPosition.x, currentPosition.y - 1)]));
            }

            if (currentPosition.y + 1 <= maxY)
            {
                neighbors.Add((currentPosition.x, currentPosition.y + 1, allPoints[(currentPosition.x, currentPosition.y + 1)]));
            }

            return neighbors.Where(n => !usedSteps.Contains((n.x, n.y))).ToList();
        }

        public class Route
        {
            public int Steps { get; set; }

            public (int x, int y) StartPosition { get; set; }

            public bool ReachedTarget = false;

            public List<(int x, int y)> UsedSteps { get; set; } = new List<(int x, int y)>();
        }
    }
}
