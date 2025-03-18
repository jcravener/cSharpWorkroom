using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Nine
{
    public class ProblemNine
    {
        private string Number { get; set; }

        public ProblemNine(int number)
        {
            Console.WriteLine($"Running: {this.GetType().Name}");

            Number = number.ToString();
        }

        public void RunProblem()
        {
            Console.WriteLine( $"{Number}: {Solve()}");
        }

        private bool Solve()
        {
            int j = Number.Length - 1;

            for(int i = 0; i < j; i++)
            {
                if (Number[i] != Number[j])
                {
                    return false;
                }
                else
                {
                    j--;
                }
            }

            return true;
        }
    }
}
