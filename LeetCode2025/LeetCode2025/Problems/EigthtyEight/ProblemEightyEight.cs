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
            int index = M + N - 1;
            M--;
            N--;

            // Walking through the arrays backwards
            // Comparing each value to one another
            // Inserting the largest or (equal) to the last possition in the longer array
            // Moving the poiter of the array in which the value was taken.
            // Always moving the pointer of the array we are inserting into 
            
            while (M >= 0 && N >= 0)
            {
                if (Nums2[N] >= Nums1[M])
                {
                    Nums1[index] = Nums2[N];
                    N--;
                }
                else
                {
                    Nums1[index] = Nums1[M];
                    M--;
                }

                index--;
            }

            return Nums1;
        }
    }
}
