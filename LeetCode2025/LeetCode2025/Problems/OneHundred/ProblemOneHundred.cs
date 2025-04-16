using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.OneHundred
{
    public class ProblemOneHundred : ProblemBase
    {
        public TreeNode A { get; set; }
        public TreeNode B { get; set; }

        public ProblemOneHundred(int example)
        {
            switch (example)
            {
                case 1:
                    A = new TreeNode(1);
                    A.InsertLeft(A, 2);
                    A.InsertRight(A, 3);

                    B = new TreeNode(1);
                    B.InsertLeft(B, 2);
                    B.InsertRight(B, 3);
                    
                    break;
                case 2:
                    A = new TreeNode(1);
                    A.InsertLeft(A, 2);
                    
                    B = new TreeNode(1);
                    B.InsertRight(B, 3);
                    
                    break;
                case 3:
                    A = new TreeNode(1);
                    A.InsertLeft(A, 2);
                    A.InsertRight(A, 1);

                    B = new TreeNode(1);
                    B.InsertLeft(B, 1);
                    B.InsertRight(B, 2);

                    break;

                default:
                    throw new Exception($"Example {example} is unknown.");
            }
        }

        public void RunProblem()
        {
            Console.WriteLine(Traverse(A, B));
        }

        private bool Traverse(TreeNode a, TreeNode b)
        {
            if(a == null && b == null) return true;

            if (a == null || b == null) return false;

            if (a.Value != b.Value) return false;

            return Traverse(a.Left, b.Left) && Traverse(a.Right, b.Right);
        }
    }
}
