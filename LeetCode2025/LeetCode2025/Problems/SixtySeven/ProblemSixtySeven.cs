using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.SixtySeven
{
    public class ProblemSixtySeven : ProblemBase
    {
        public string A { get; set; }
        public string B { get; set; }

        public ProblemSixtySeven(string a, string b )
        {
            A = a;
            B = b;
        }

        public void RunProblem()
        {
            Console.WriteLine(Solve());
        }

        private string Solve()
        {
            (string large, string small) = GetLargeSmall(A, B);
            int largePointer = large.Length - 1;
            int smallPointer = small.Length - 1;

            bool carry = false;
            string answer = string.Empty;

            while(smallPointer >= 0)
            {
                (carry, answer) = UpdateAnswer(carry, answer, large[largePointer], small[smallPointer]);
                largePointer--;
                smallPointer--;
            }

            if (large.Length != small.Length)
            {
                while(largePointer >= 0)
                {
                    (carry, answer) = UpdateAnswer(carry, answer, large[largePointer], '0');
                    largePointer --;
                }
            }

            if (carry)
            {
                (carry, answer) = UpdateAnswer(carry, answer);
            }

            return answer;
        }

        private (string, string) GetLargeSmall(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return (a, b);
            }
            
            return (b, a);
        }

        private (bool, string) UpdateAnswer(bool carry, string answer, char a = '0', char b ='0')
        {
            int val = int.Parse(a.ToString()) + int.Parse(b.ToString());

            if (val == 0)
            {
                if (carry) // 001
                {
                    answer = $"1{answer}";
                }
                else // 00
                {
                    answer = $"0{answer}";
                }
                carry = false;
            }
            else if (val == 1)
            {
                if (carry) // 101
                {
                    answer = $"0{answer}";
                    carry = true;
                }
                else // 10
                {
                    answer = $"1{answer}";
                    carry = false;
                }
            }
            else // val == 2
            {
                if (carry) // 111
                {
                    answer = $"1{answer}";
                }
                else // 11
                {
                    answer = $"0{answer}";
                }
                carry = true;
            }

            return (carry, answer);
        }
    }
}
