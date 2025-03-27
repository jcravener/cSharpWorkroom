using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.TwentySix
{
    public class ProblemTwentySix : ProblemBase
    {
        public int[] Nums { get; set; }
        
        public ProblemTwentySix(int[] nums)
        {
            Nums = nums;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private int Solve()
        {
            int lastValidPosition = -1;
            int lastVal = -101;
            
            for(int i  = 0; i < Nums.Length; i++)
            {
                int currentVal = Nums[i];

                if(currentVal != lastVal)
                {
                    Nums[lastValidPosition+1] = currentVal;
                    lastVal = currentVal;
                    lastValidPosition = lastValidPosition + 1;
                }
            }

            return lastValidPosition+1;
        }
    }
}
