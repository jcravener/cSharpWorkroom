using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.OneHundredOne
{
    public class ProblemOneHundredOne : ProblemBase
    {
        public TreeNode Root { get; set; }
        
        public ProblemOneHundredOne(int example)
        {
            switch (example)
            {
                case 1:
                    Root = new TreeNode(1);

                    Root.Left = new TreeNode(2);
                    Root.Right = new TreeNode(2);

                    Root.Left.Left = new TreeNode(3);
                    Root.Left.Right = new TreeNode(4);

                    Root.Right.Left = new TreeNode(4);
                    Root.Right.Right = new TreeNode(3);

                    break;
                default:
                    throw new Exception($"Example {example} is unknown");
            }
        }

        public void RunProblem()
        {
            Console.WriteLine(SymCheck(Root.Left, Root.Right));
        }

        private bool SymCheck(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            return left.Value == right.Value
                && SymCheck(left.Left, right.Right)
                && SymCheck(left.Right, right.Left);
        }
    }
}
