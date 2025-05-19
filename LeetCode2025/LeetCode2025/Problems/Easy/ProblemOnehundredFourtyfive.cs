using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    internal class ProblemOnehundredFourtyfive : ProblemBase
    {
        public TreeNode Root { get; set; }

        public ProblemOnehundredFourtyfive(int example)
        {
            switch (example)
            {
                case 1:
                    Root = new TreeNode(1);
                    Root.Right = new TreeNode(2);
                    Root.Right.Left = new TreeNode(3);
                    break;
                default:
                    throw new Exception($"Example: {example} unknown.");
            }
        }

        public void RunProblem()
        {
            List<int> list = new();

            Solve(Root, list);

            Console.WriteLine(ProblemBase.ToString(list));
        }


        private void Solve(TreeNode node, List<int> list)
        {
            if(node == null) return;

            Solve(node.Left, list);
            Solve(node.Right, list);

            list.Add(node.Value);
        }
    }
}
