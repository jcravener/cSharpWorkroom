using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Three
{
    public class ProblemThree : ProblemBase
    {
        private string Input { get; set; }

        public ProblemThree(string input) : base()
        {
            Input = input;
        }

        public void RunProblem()
        {
            int startPointer = 0;
            int maxLength = 0;
            Dictionary<char, int> startPointerRef = new();

            for(int i = 0; i < Input.Length; i++)
            {
                char c = Input[i];

                if (startPointerRef.ContainsKey(c))
                {
                    startPointer = startPointerRef[c] + 1;
                }
                else
                {
                    startPointerRef.Add(c, i);

                    var length = i - startPointer + 1;

                    if(length > maxLength)
                    {
                        maxLength = length;
                    }
                }
            }

            Console.WriteLine($"{Input}: {maxLength}");
        }
    }
}
