using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProbOneSixtyeight : ProblemBase
    {
        public string Input { get; set; }

        private Dictionary<char, int> map { get; set; }

        public ProbOneSixtyeight(string input)
        {
            Input = input;

        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private double Solve()
        {
            double result = 0;

            int power = 0;

            foreach (char c in Input.Reverse())
            {
                result += Math.Pow(26, power);
                power++;
            }

            return result;
        }

        private int CharVal(char c)
        {
            return Convert.ToInt32(c) - 64;
        }
    }
}
