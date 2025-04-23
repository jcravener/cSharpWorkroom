using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    public class ProblemOnehundredTen : ProblemBase
    {
        public TreeNode Root { get; set; }

        public ProblemOnehundredTen(int example)
        {
            switch (example)
            {
                case 1:
                    Root = new TreeNode(3);
                    Root.Left = new TreeNode(9);
                    Root.Right = new TreeNode(20);
                    Root.Right.Left = new TreeNode(15);
                    Root.Right.Right = new TreeNode(7);
                    break;

                case 2:
                    Root = new TreeNode(1);
                    Root.Left = new TreeNode(2);
                    Root.Right = new TreeNode(2);
                    Root.Left.Right = new TreeNode(3);
                    Root.Left.Left = new TreeNode(3);
                    Root.Left.Left.Right = new TreeNode(4);
                    Root.Left.Left.Left = new TreeNode(4);
                    break;
                
                default:
                    throw new Exception($"example {example} unknown!");
            }

        }

        public void RunProblem()
        {
            Console.WriteLine(IsBallanced(Root));
        }

        private bool IsBallanced(TreeNode node)
        {
            int left = MaxDepth(node.Left);

            int right = MaxDepth(node.Right);

            return Math.Abs(left - right) <= 1;
        }

        private int MaxDepth(TreeNode node)
        {
            if (node == null) return 0;

            return 1 + Math.Max(MaxDepth(node.Left), MaxDepth(node.Right));
        }
    }
}
