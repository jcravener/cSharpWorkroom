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
                    //startPointer = Math.Max( startPointer, startPointerRef[c] + 1);

                    // This if-condition does the same thing as the Math.Max assignment.
                    // The important part here is to ensure the startPointer does not move backwards.
                    // If it does it go back and count characters incorrectly.
                    if (startPointerRef[c] + 1 > startPointer)
                    {
                        startPointer = startPointerRef[c] + 1;
                    }
                    
                    startPointerRef[c] = i;
                }
                else
                {
                    startPointerRef.Add(c, i);
                }

                // It is also important to calulate the length, each time you encounter a new char.
                var length = i - startPointer + 1;

                //maxLength = Math.Max(maxLength, length);

                //This if-condition could have also been replaced with the above Math.Max assignment
                if (length > maxLength)
                {
                    maxLength = length;
                }

            }

            Console.WriteLine($"{Input}: {maxLength}");
        }
    }
}
