using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredThritysix : ProblemBase
    {
        public int[] Nums { get; set; }

        public ProblemOnehundredThritysix(int[] nums)
        {
            Nums = nums;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private int Solve()
        {
            var records = new HashSet<int>();

            foreach (int i in Nums)
            {
                if (!records.Contains(i))
                {
                    records.Add(i);
                }
                else
                {
                    records.Remove(i);
                }
            }

            foreach (int i in records)
            {
                return i;
            }

            return 0;
        }
    }
}
