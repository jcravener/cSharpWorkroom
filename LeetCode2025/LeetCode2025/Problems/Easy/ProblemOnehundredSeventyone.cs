using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredSeventyone : ProblemBase
    {
        private string ColumnTitle { get; set; }

        public ProblemOnehundredSeventyone(string columnTitle)
        {
            ColumnTitle = columnTitle;
        }

        public void RunProblem()
        {
            Console.WriteLine(ProblemBase.ToString(Solve()));
        }

        private IEnumerable<int> Solve()
        {
            string columnTitle = ColumnTitle;

            List<int> returnList = new();

            foreach( char c in columnTitle)
            {
                returnList.Add(GetNumber(c));
            }

            return returnList;
        }

        private int GetNumber(char c)
        {
            return ((int)c - 64);
        } 
    }
}
