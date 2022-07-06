using System;
using System.Collections.Generic;

namespace Plus_One
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = { 9, 9 };
            Solution solution = new Solution();

            foreach(int i in solution.PlusOne(digits))
            {
                Console.WriteLine($"{i}");
            }
        }
    }

    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            List<int> rt = new List<int>(digits);

            // This only works for the case where the last digit in 9
            // It fails when the 2nd to the last digit in 9.  e.g. [9,9]
            // Seems a recursive solution would be on order.
            // But maybe an iterative solution wold work as well.

            if (digits[^1] < 9)
            {
                rt[^1]++;
            }
            else
            {
                rt[^1] = 1;
                rt.Add(0);
            }
 
            return rt.ToArray();
        }
    }
}
