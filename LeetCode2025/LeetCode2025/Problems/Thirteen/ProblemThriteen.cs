using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Thirteen
{
    public class ProblemThriteen
    {
        private static Dictionary<char, int> Map = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        private string Numeral { get; set; }

        public ProblemThriteen(string numeral)
        {
            Numeral = numeral;
        }

        public void RunProblem()
        {
            Console.WriteLine($"{Numeral}: {Solve()}");
        }

        public int Solve()
        {
            char curent;
            char next;
            int val = 0;
            int sum = 0;

            for (int i = 0; i < Numeral.Length; i++)
            {
                curent = Numeral[i];
                val = Map[curent];

                if ( i+1 < Numeral.Length)
                {                    
                    next = Numeral[i + 1];

                    if(Map[curent] < Map[next])
                    {
                        val = Map[next] - Map[curent];
                        i++;
                    }
                }
                
                sum += val;
            }

            return sum;
        }
    }
}
