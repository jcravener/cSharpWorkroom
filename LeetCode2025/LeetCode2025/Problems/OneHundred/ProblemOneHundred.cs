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
        List<int> ListA { get; set; }
        List<int> ListB { get; set; }

        BinarySerachTree A { get; set; }
        BinarySerachTree B { get; set; }

        public ProblemOneHundred(List<int> listA, List<int> listB)
        {
            ListA = listA;
            ListB = listB;

            A = new BinarySerachTree();
            B = new BinarySerachTree();

            BuildTree(A, ListA);
            BuildTree(B, ListB);
        }

        public void RunProblem()
        {
            List<int> outA = new();
            List<int> outB = new();

            Traverse(A.Root, outA);
            Traverse(B.Root, outB);

            Console.WriteLine(ToString((outA)));
            Console.WriteLine(ToString((outB)));
        }

        private bool Solve()
        {
            return true;
        }

        private void BuildTree(BinarySerachTree tree, List<int> ints)
        {
            foreach (int i in ints)
            {
                tree.Insert(i);
            }
        }

        private void Traverse(TreeNode node, List<int> outList) // TODO:  This while loop never ends.
        {
            while(node != null)
            {
                Traverse(node.Left, outList);
                outList.Add(node.Value);
                Traverse(node.Right, outList);
            }
        }
    }
}
