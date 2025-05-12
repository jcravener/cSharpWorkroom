using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredTwentyfive : ProblemBase
    {
        public string Input { get; set; }

        public ProblemOnehundredTwentyfive(string input)
        {
            Input = input;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private bool Solve()
        {
            string phrase = Sanitize(Input);

            int midpoint = phrase.Length / 2;

            for (int i = 0; i < midpoint; i++)
            {
                if (phrase[i] != phrase[(phrase.Length - 1) - i])
                {
                    return false;
                }
            }

            return true;
        }

        private string Sanitize(string s)
        {
            var builder = new StringBuilder();

            foreach (char c in s)
            {
                if(c >= 'A' && c <= 'Z')
                {
                    builder.Append((char)(c+32));
                }
                else if((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z'))
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
