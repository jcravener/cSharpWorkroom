using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Fourteen
{
    public class ProblemFourteen : ProblemBase
    {
        public string[] Strings { get; set; }

        public ProblemFourteen(string[] strings) 
        { 
            Strings = strings;
        }

        public void RunProblem()
        {
            Console.WriteLine($"{Solve()}");
        }

        private string Solve()
        {
            string[] strs = Strings;
            string answer = string.Empty;
            int minLength = strs[0].Length;

            foreach(string s in strs)
            {
                minLength = Math.Min(minLength, s.Length);
            }
            
            for(int i = 0; i < minLength; i++)
            {
                char c = strs[0][i];

                for(int j = 0; j < strs.Length; j++)
                {
                    string s = strs[j];
                    
                    if(c != s[i])
                    {
                        return answer;
                    }

                    if(j == strs.Length - 1)
                    {
                        answer += s[i];
                    }
                }
            }

            return answer;
        }
    }
}
