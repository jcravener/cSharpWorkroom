using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems
{
    public class ProblemBase
    {
        public ProblemBase()
        {
            Console.WriteLine();
            Console.WriteLine($"Running: {this.GetType().Name}.");
        }

        protected static string ToString(int[] a)
        {
            string str = string.Empty;
            
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0)
                {
                    str += "[";
                }

                str+= a[i];

                if (i < a.Length - 1)
                {
                    str += ",";
                }
                else
                {
                    str += "]";
                }
            }

            return str;
        }
    }
}
