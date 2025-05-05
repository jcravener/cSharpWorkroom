using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    public class ProblemOnehundredTwevle : ProblemBase
    {
        TreeNode Root { get; set; }

        int Sum { get; set; }

        public ProblemOnehundredTwevle(int example)
        {
            switch (example)
            {
                case 1:
                    Sum = 22;
                    
                    Root = new TreeNode(5);
                    
                    Root.Left = new TreeNode(4);
                    Root.Left.Left = new TreeNode(11);
                    Root.Left.Left.Left = new TreeNode(7);
                    Root.Left.Left.Right = new TreeNode(2);
                    
                    Root.Right = new TreeNode(8);
                    Root.Right.Left = new TreeNode(13);
                    Root.Right.Right = new TreeNode(4);
                    Root.Right.Right = new TreeNode(1);
                
                break;
                default:
                    throw new Exception($"Example: {example} unknown.");
            }
        }

        public void RunProblem()
        {
            Console.WriteLine(PathSum(Root, Sum));
        }

        private bool PathSum(TreeNode node, int sum)
        {
            if (node == null) return false;

            if (node.Left == null && node.Right == null && node.Value == sum) return true;

            var left = PathSum(node.Left, sum - node.Value);
            var right = PathSum(node.Right, sum - node.Value);

            return left || right;
        }
    }
}
