using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day02
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day02/Step1Input.txt");

            //rock = 1
            //paper = 2
            //scissor = 3

            //lost = 0
            //draw = 3
            //win = 6

            //opponent: rock = A, paper = B, scissor = C
            //me: rock = X, paper = Y, scissor = Z

            var totalPoints = 0;

            foreach (var i in input)
            {
                var roundPoints = 0;

                var chosen = i.Split(' ');

                var oppo = GetPoints(chosen[0]);
                var me = GetPoints(chosen[1]);

                roundPoints = GetMyResult(oppo, me);

                totalPoints += roundPoints;
            }

            Console.WriteLine($"TotalRoundPoints: {totalPoints}");
        }

        private int GetPoints(string input)
        {
            if (input == "A" || input == "X")
            {
                return 1;
            }
            else if (input == "B" || input == "Y")
            {
                return 2;
            }
            else if (input == "C" || input == "Z")
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        private int GetMyResult(int oppo, int me)
        {
            if (oppo == me)
            {
                return 3 + me;
            }
            else if (oppo == 1 && me == 2)
            {
                return 6 + me;
            }
            else if (oppo == 1 && me == 3)
            {
                return 0 + me;
            }
            else if (oppo == 2 && me == 1)
            {
                return 0 + me;
            }
            else if (oppo == 2 && me == 3)
            {
                return 6 + me;
            }
            else if (oppo == 3 && me == 1)
            {
                return 6 + me;
            }
            else if (oppo == 3 && me == 2)
            {
                return 0 + me;
            }

            return 0;
        }
    }
}
