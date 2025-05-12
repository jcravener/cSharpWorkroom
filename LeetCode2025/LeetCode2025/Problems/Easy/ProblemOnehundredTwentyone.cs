using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredTwentyone : ProblemBase
    {
        public int[] Prices { get; set; }

        public ProblemOnehundredTwentyone(int[] prices)
        {
            Prices = prices;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private int Solve()
        {
            int profit = 0;
            
            for(int i = 0; i < Prices.Length; i++)
            {
                for(int j = i + 1; j < Prices.Length; j++)
                {
                    if(Prices[i] < Prices[j])
                    {
                        int val = Prices[j] - Prices[i];

                        profit = Math.Max(profit, val);
                    }
                    else
                    {
                        i = j;
                    }
                }
            }

            return profit;
        }
    }
}
