using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Twentyeight
{
    public class ProblemTwentyEight : ProblemBase
    {
        public string Haystack { get; set; }

        public string Needle { get; set; }


        public ProblemTwentyEight(string haystack, string needle)
        { 
            Haystack = haystack;
            Needle = needle;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private int Solve()
        {
            int len = Needle.Length;

            for(int i = 0; i < Haystack.Length; i++)
            {
                if(i + len - 1 >= Haystack.Length)
                {
                    return -1;
                }

                string sub = Haystack.Substring(i, len);

                if(sub == Needle)
                {
                    return i;
                }
            }
            
            return -1;
        }
    }
}
