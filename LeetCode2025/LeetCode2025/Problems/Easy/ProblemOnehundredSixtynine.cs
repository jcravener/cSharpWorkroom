using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredSixtynine : ProblemBase
    {
        private int[] Nums { get; set; }

        public ProblemOnehundredSixtynine(int[] nums)
        {
            Nums = nums;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private int Solve()
        {
            int[] nums = Nums;
            
            Dictionary<int, int> records = new();

            if (nums.Length == 1) return nums[0];

            int limit = nums.Length / 2;

            foreach (int i in nums)
            {
                if (records.ContainsKey(i))
                {
                    records[i]++;
                    if (records[i] > limit) return i;
                }
                else
                {
                    records.Add(i, 1);
                }
            }

            return 0;
        }
    }
}
