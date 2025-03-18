using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Three
{
    public class ProblemThree
    {
        private int front { get; set; }
        private int back { get; set; }
        
        
        private string Input { get; set; }
        private int Max { get; set; }
        private int CurrentMax { get; set; }
        private Queue<char> Chars { get; set; }
        
        public ProblemThree(string input) 
        {
            Console.WriteLine($"Running: {this.GetType().Name}.");

            Input = input;
            Max = 0;
            CurrentMax = 0;
            Chars = new();
        }

        public void RunProblem()
        {
            //TODO: Continue working to find a solution to all test cases.
            
            foreach (char c in Input)
            {
                if (Chars.Contains(c))
                {                                       
                    if(Chars.Peek() != c)
                    {
                        Chars.Enqueue(c);
                    }

                    Chars.Dequeue();
                }
                else
                {
                    Chars.Enqueue(c);
                }

                CurrentMax = Chars.Count;

                if(CurrentMax > Max)
                {
                    Max = CurrentMax;
                }
            }

            Console.WriteLine(Max.ToString());
        }
    }
}
