using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.EigthtyEight
{
    public class ProblemEightyEight : ProblemBase
    {
        public int[] Nums1 { get; set; }
        public int[] Nums2 { get; set; }
        public int M { get; set; }
        public int N { get; set; }

        public ProblemEightyEight(int[] nums1, int m, int[] nums2, int n)
        {
            Nums1 = nums1;
            Nums2 = nums2;
            M = m;
            N = n;
        }

        public void RunProblem()
        {
            Console.WriteLine(ToString(Solve()));
        }

        private int[] Solve()
        {
            int[] dummy = Nums1;
            int indexDummy = 0;
            int indexM = 0;
            int indexN = 0;

            if (M == 0)
            {
                return Nums2;
            }

            if (N == 0)
            {
                return Nums1;
            }

            // TODO: This is not solved

            while(indexM <= M + N)
            {
                if (dummy[indexDummy] <= Nums2[indexN])
                {
                    Nums1[indexDummy] = dummy[indexDummy];
                    indexDummy++;
                }
                else
                {
                    Nums1[indexDummy] = Nums2[indexN];
                    indexN++;
                }
            }

            return Nums1;
        }
    }
}
