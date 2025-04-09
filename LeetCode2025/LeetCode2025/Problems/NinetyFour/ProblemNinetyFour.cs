using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.NinetyFour
{
    public class ProblemNinetyFour : ProblemBase
    {
        public TreeNode Node { get; set; }
        
        public void RunProblem(TreeNode node)
        {
            Node = node;
        }


        private void Solve()
        {
            List<int> list = new();

            Traverse(Node, list);

            int[] ints = new int[list.Count];

            foreach (int i in list) ints[i] = i;

            Console.WriteLine(ToString(ints));
        }


        private void Traverse(TreeNode? node, List<int> list)
        {
            if(node != null)
            {
                Traverse(node.Left, list);
                list.Add(node.Value);
                Traverse(node.Right, list);
            }
        }
    }
}
