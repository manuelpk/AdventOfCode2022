using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day10
{
    public class Step2
    {
        int currentPos = 0;
        int spritePos = 1;

        public Step2()
        {
            var input = File.ReadAllLines("Day10/Step1Input.txt");

            var row = string.Empty;
            var rows = new List<string>();

            foreach (var i in input)
            {
                row = Check(row, rows);

                currentPos++;

                if (i.Split(" ")[0] == "addx")
                {
                    row = Check(row, rows);

                    currentPos++;

                    spritePos = spritePos + int.Parse(i.Split(" ")[1]);
                }
            }

            rows.Add(row);

            rows.ForEach(r => Console.WriteLine(r));
        }

        private string Check(string row, List<string> rows)
        {
            if (currentPos == 40)
            {
                rows.Add(row);
                currentPos = 0;

                return "#";
            }
            else
            {
                if (currentPos <= spritePos + 1 && currentPos >= spritePos - 1)
                {
                    return row + "#";
                }
                else
                {
                    return row + ".";
                }
            }
        }
    }
}
