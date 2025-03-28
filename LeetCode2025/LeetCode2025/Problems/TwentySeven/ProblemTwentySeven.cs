using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.TwentySeven
{
    public class ProblemTwentySeven : ProblemBase
    {
        public int[] Nums { get; set; }

        public int Value { get; set; }

        public ProblemTwentySeven(int[] nums, int val) 
        {
            Nums = nums;
            Value = val;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private int Solve()
        {
            int lastValidPosition = -1;

            for(int i = 0; i < Nums.Length; i++)
            {
                int currentVal = Nums[i];
                
                if(currentVal != Value)
                {
                    Nums[lastValidPosition + 1] = currentVal;
                    lastValidPosition = lastValidPosition + 1;
                }
            }

            return lastValidPosition + 1;
        }
    }
}
