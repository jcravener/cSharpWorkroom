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
        
        public ProblemNinetyFour(IList<int?> ints)
        {
            var tree = new BinarySerachTree();
            
            foreach (int i in ints)
            {
                tree.Insert(i);
            }

            Node = tree.Root;
        }
        
        
        public void RunProblem()
        {
            Solve();
        }

        private void Solve()
        {
            List<int> list = new();

            Console.WriteLine(ToString(list));
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
