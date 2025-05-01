using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    public class ProblemOnehundredEleven : ProblemBase
    {
        public TreeNode Root { get; set; }
        
        public ProblemOnehundredEleven(int example)
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
                    Root = new TreeNode(2);
                    Root.Right = new TreeNode(3);
                    break;
                default:
                    throw new Exception($"Example {example} unknown.");
            }
        }

        public void RunProblem()
        {
            Console.WriteLine(BFSDepthCheck(Root));
        }

        private int BFSDepthCheck(TreeNode node)
        {
            Queue<(TreeNode, int)> queue = new();

            queue.Enqueue((node, 1));

            while (queue.Count > 0)
            {
                var (n, i) = queue.Dequeue();

                if (n.Left == null && n.Right == null) return i;

                if(n.Left != null) queue.Enqueue((n.Left, i+1));

                if(n.Right != null) queue.Enqueue((n.Right, i+1));
            }

            return -1;
        }
    }
}
