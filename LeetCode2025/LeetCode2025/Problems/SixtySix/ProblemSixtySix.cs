using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.SixtySix
{
    public class ProblemSixtySix : ProblemBase
    {
        public int[] Digits { get; set; }

        public ProblemSixtySix(int[] digits ) : base()
        {
            Digits = digits;
        }

        public void RunProblem()
        {
            string a = ProblemBase.ToString(Solve());
            Console.WriteLine(a);
        }

        private int[] Solve()
        {
            BigInteger val = 0;
            int power = 0; 

            for(int i = Digits.Length - 1; i >= 0; i--)
            {
                val += Digits[i] * BigInteger.Pow(10, power);
                power++;
            }

            val = val + 1;

            string valStr = val.ToString();
            int[] answer = new int[valStr.Length];

            for (int i = 0; i < valStr.Length; i++)
            {
                int d = valStr[i] == '0' 
                    ? 0 
                    : int.Parse(valStr[i].ToString());

                answer[i] = d;
            }

            return answer;
        }
    }
}
