using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.FiftyEight
{
    public class ProblemFiftyEight : ProblemBase
    {
        public string S { get; set; }
        
        public ProblemFiftyEight(string s)
        { 
            S = s;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        public int Solve()
        {
            int length = 0;
            
            for (int i = S.Length - 1; i >= 0; i--)
            {
                char c = S[i];

                if(length == 0 && c == ' ')
                {
                    continue;
                }

                if (c == ' ')
                {
                    break;
                }
                else
                {
                    length++;
                }
            }

            return length;
        }
    }
}
