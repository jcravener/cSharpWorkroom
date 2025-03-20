using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Twenty
{
    public class ProblemTwenty : ProblemBase
    {
        public string Input { get; set; }
        
        public ProblemTwenty(string input) : base()
        { 
            Input = input;
        }

        public void RunProblem()
        {
            Console.WriteLine($"{Input}: {Solve()}");
        }

        // TODO: Not working.  Need to fix.
        private bool Solve()
        {
            var s = Input;
            
            if (s.Length % 2 != 0)
            {
                return false;
            }

            HashSet<char> open = new() { '(', '{', '[' };

            Stack<char> openChars = new();

            foreach (char c in s)
            {
                if (open.Contains(c))
                {
                    openChars.Push(c);
                }
                else
                {
                    char cc;

                    if (openChars.Count > 0)
                    {
                        cc = openChars.Pop();
                    }
                    else
                    {
                        return false;
                    }

                    if (GetType(c) != GetType(cc))
                    {
                        return false;
                    }
                }
            }

            if (openChars.Count > 0)
            {
                return false;
            }

            return true;
        }

        private int GetType(char c)
        {
            List<HashSet<char>> types = new()
            {
                new HashSet<char> { '(', ')' },
                new HashSet<char> { '{', '}' },
                new HashSet<char> { '[', ']' },
            };

            for(int i = 0; i < types.Count; i++)
            {
                if (types[i].Contains(c))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
