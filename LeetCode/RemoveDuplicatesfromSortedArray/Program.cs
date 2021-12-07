using System;

namespace RemoveDuplicatesfromSortedArray
{
    class Program
    {
        static void Main()
        {
            //int[] a = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //int[] a = { 1, 1, 2, 2, 3, 3 };
            int[] a = { };

            Console.WriteLine(RemoveDuplicates(a).ToString());
        }

        public static int RemoveDuplicates(int[] nums)
        {            
            if(nums.Length <= 1)
            {
                return nums.Length;
            }

            int position = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if(nums[i] > nums[i-1])
                {
                    nums[position] = nums[i];
                    position += 1;
                }
            }
            
            return position;
        }
    }
}
