using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredSixtyeight : ProblemBase
    {

        private int Num { get; set; }

        public ProblemOnehundredSixtyeight(int num)
        {
            Num = num;
        }


        public void runProblem()
        {
            Console.WriteLine(Solve(Num));
        }

        private string Solve(int num)
        {
            if (num <= 0) throw new Exception("number must be greater than 0");

            num--;

            if (num < 26) return GetChar(num + 1).ToString();

            int rem = num % 26;
            int quo = num / 26;

            return Solve(quo) + GetChar(rem + 1);
        }

        private char GetChar(int i)
        {
            if (i < 1 || i > 26) throw new ArgumentException("Number must be between 1 and 26");

            return (char)('A' + (i - 1));
        }
    }
}
