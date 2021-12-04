using System;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 17;

            Solution sol = new Solution();

            foreach(int i in sol.TwoSum(nums, target))
            {
                Console.WriteLine(i.ToString());
            }
            
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] rt = new int[2];

            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j < nums.Length; j++)
                {
                    if( j == i)
                    {
                        continue;
                    }
                    
                    if(nums[i] + nums[j] == target)
                    {
                        rt[0] = i; rt[1] = j;
                        return rt;
                    }
                }
            }
            return rt;
        }
    }
}
