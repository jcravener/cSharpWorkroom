using System;
using System.Collections.Generic;

namespace Plus_One
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = { 1, 9 };
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

            if (rt[^1] < 9)
            {
                rt[^1]++;
            }
            else
            {
                for(int i = rt.Count - 1; i >= 0; i--)
                {
                    if(rt[i] == 9)
                    {
                        rt[i] = 0;

                        if(i == 0)
                        {
                            rt.Insert(0, 1);
                        }
                    }
                    else
                    {
                        rt[i]++;
                        break;
                    }
                }
            }
 
            return rt.ToArray();
        }
    }
}
