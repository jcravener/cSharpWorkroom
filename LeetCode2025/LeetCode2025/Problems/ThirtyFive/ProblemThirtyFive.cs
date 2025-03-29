using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.ThirtyFive
{
    public class ProblemThirtyFive : ProblemBase
    {
        public int[] Nums { get; set; }
        public int Target { get; set; }

        public ProblemThirtyFive(int[] nums, int target)
        {
            Nums = nums;
            Target = target;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private int Solve()
        {
            // TODO: This is accepted but runs too slow
            //List<int> list = new(Nums);
            //list.Add(Target);
            //list.Sort();
            //return list.IndexOf(Target);

            // TODO: Implement binary serach

            int left = 0;
            int right = Nums.Length - 1;
            
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if(Target == Nums[mid])
                {
                    return mid;
                }
                else if(Target < Nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }
    }
}
