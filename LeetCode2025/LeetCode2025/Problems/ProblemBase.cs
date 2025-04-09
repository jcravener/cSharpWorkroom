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

        protected static string ToString<T>(IEnumerable<T> collection)
        {
            if(collection == null || !collection.Any())
            {
                return "[]";
            }
            
            string str = "[";

            foreach(var item in collection)
            {
                str += $"{item},";
            }

            str = str.TrimEnd(',') + "]";

            return str;
        }
    }
}
