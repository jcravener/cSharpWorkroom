using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.OneHundredFour
{
    public class ProblemOneNumdredFour : ProblemBase
    {
        public TreeNode Root { get; set; }
        
        public ProblemOneNumdredFour(int example)
        {
            switch (example)
            {
                case 1:
                    Root = new TreeNode(3);
                    Root.Left = new TreeNode(9);
                    Root.Right = new TreeNode(20);
                    Root.Right.Right = new TreeNode(15);
                    Root.Right.Left = new TreeNode(7);
                    break;

                default:
                    throw new Exception($"Example {example} unknown.");
            }
        }

        public void RunProblem()
        {
            Console.WriteLine(MaxDepth(Root));
        }

        private int MaxDepth(TreeNode node)
        {
            if(node == null) return 0;

            return 1 + Math.Max(MaxDepth(node.Left), MaxDepth(node.Right));
        }
    }
}
