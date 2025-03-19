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
    }
}
