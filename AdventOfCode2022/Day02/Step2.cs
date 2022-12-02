using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day02
{
    public class Step2
    {
        public Step2()
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

            //X means you need to lose
            //Y means you need to end the round in a draw
            //Z means you need to win

            var totalPoints = 0;

            foreach (var i in input)
            {
                var roundPoints = 0;

                var chosen = i.Split(' ');

                if (chosen[1] == "X")
                {
                    roundPoints = GetLosePoints(GetPoints(chosen[0]));
                }
                else if (chosen[1] == "Y")
                {
                    roundPoints = GetDrawPoints(GetPoints(chosen[0]));
                }
                else if (chosen[1] == "Z")
                {
                    roundPoints = GetWinPoints(GetPoints(chosen[0]));
                }

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

        private int GetLosePoints(int oppo)
        {
            if (oppo == 1)
            {
                return 3;
            }
            else if (oppo == 2)
            {
                return 1;
            }
            else if (oppo == 3)
            {
                return 2;
            }

            return 0;
        }

        private int GetDrawPoints(int oppo)
        {
            return 3 + oppo;
        }

        private int GetWinPoints(int oppo)
        {
            if (oppo == 1)
            {
                return 6 + 2;
            }
            else if (oppo == 2)
            {
                return 6 + 3;
            }
            else if (oppo == 3)
            {
                return 6 + 1;
            }

            return 0;
        }
    }
}
