using System;

namespace RemoveElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3,2,2,3 };
            int v = 3;
            
            Console.WriteLine(RemoveElement(a, v).ToString());
        }

        public static int RemoveElement(int[] nums, int val)
        {            
            if (nums.Length == 0)
            {
                return nums.Length;
            }

            if(nums.Length == 1 && nums[0] == val)
            {
                nums[0] = val + 1;
            }

            int count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    nums[i] = 101;
                    count++;
                }
            }

            Array.Sort(nums);

            return nums.Length-count;
        }
    }
}
