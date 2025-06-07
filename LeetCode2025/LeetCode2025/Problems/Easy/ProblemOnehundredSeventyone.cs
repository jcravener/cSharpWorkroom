using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredSeventyone : ProblemBase
    {
        public string ColumnTitle { get; set; }

        public ProblemOnehundredSeventyone(string columnTitle)
        {
            ColumnTitle = columnTitle;
        }

        public void RunProblem()
        {
            Console.WriteLine(ColumnTitle);

            var foo = Solve();

            Console.WriteLine(ProblemBase.ToString(foo));

            Console.WriteLine(AddNums(foo));
        }

        private IEnumerable<int> Solve()
        {
            string columnTitle = ColumnTitle;

            List<int> returnList = new();

            var power = columnTitle.Length - 1;

            foreach(char c in columnTitle)
            {
                int number = GetNumber(c);
                double val = Math.Pow(26, power) * number;
                returnList.Add((int)val);
                power--;
            }

            return returnList;
        }

        private int GetNumber(char c)
        {
            return ((int)c - 64);
        }

        private int AddNums(IEnumerable<int> nums)
        {
            int val = 0;

            foreach(int num in nums)
            {
                val += num;
            }

            return val;
        }
    }
}
