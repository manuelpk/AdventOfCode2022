using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day11
{
    public class Step1
    {
        public Step1()
        {
            var input = File.ReadAllLines("Day11/Step1Input.txt");

            var monkeys = new List<Monkey>();

            Monkey monkey = null;

            foreach (var i in input)
            {
                if (i.StartsWith("Monkey"))
                {
                    if (monkey != null)
                    {
                        monkeys.Add(monkey);
                    }

                    monkey = new Monkey();
                    monkey.MonkeyId = int.Parse(Regex.Match(i, @"\d+").Value);
                }
                else if (i.Trim().StartsWith("Starting"))
                {
                    monkey.Items = Regex.Matches(i, @"\d+").Select(x => decimal.Parse(x.Value)).ToList();
                }
                else if (i.Trim().StartsWith("Operation"))
                {
                    monkey.OperationValue = Regex.Match(i, @"\d+").Success ? Regex.Match(i, @"\d+").Value : "old";
                    monkey.Operator = Regex.Match(i, @"\*|\+").Value;
                }
                else if (i.Trim().StartsWith("Test"))
                {
                    monkey.DivisibleBy = int.Parse(Regex.Match(i, @"\d+").Value);
                }
                else if (i.Trim().StartsWith("If true"))
                {
                    monkey.IfTrueMonkeyId = int.Parse(Regex.Match(i, @"\d+").Value);
                }
                else if (i.Trim().StartsWith("If false"))
                {
                    monkey.IfFalseMonkeyId = int.Parse(Regex.Match(i, @"\d+").Value);
                }
            }

            monkeys.Add(monkey);

            for (int i = 0; i < 20; i++)
            {
                foreach (var m in monkeys.ToList())
                {
                    foreach (var item in m.Items.ToList())
                    {
                        m.InspectionCount++;

                        var newValue = Calculate(m.Operator, item, m.OperationValue);

                        var check = newValue % m.DivisibleBy == 0;

                        if (check)
                        {
                            monkeys.FirstOrDefault(x => x.MonkeyId == m.IfTrueMonkeyId)?.Items.Add(newValue);
                        }
                        else
                        {
                            monkeys.FirstOrDefault(x => x.MonkeyId == m.IfFalseMonkeyId)?.Items.Add(newValue);
                        }

                        m.Items.Remove(item);
                    }
                }
            }

            var mostActive = monkeys.OrderByDescending(x => x.InspectionCount).Select(x => x.InspectionCount).Take(2).ToList();
            var level = mostActive[0] * mostActive[1];

            Console.WriteLine($"Level: {level}");
        }

        private decimal Calculate(string op, decimal itemValue, string operationValue)
        {
            var value = operationValue == "old" ? itemValue : int.Parse(operationValue);

            if (op == "*")
            {
                return Math.Floor((itemValue * value) / 3);
            }
            else
            {
                return Math.Floor((itemValue + value) / 3);
            }
        }
    }

    public class Monkey
    {
        public int MonkeyId { get; set; }

        public List<decimal> Items { get; set; }

        public string Operator { get; set; }

        public string OperationValue { get; set; }

        public int DivisibleBy { get; set; }

        public int IfTrueMonkeyId { get; set; }

        public int IfFalseMonkeyId { get; set; }

        public decimal InspectionCount { get; set; } = 0;
    }
}
