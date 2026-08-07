using System;
using System.Text.RegularExpressions;

namespace CodingPractice2026.Examples
{
    internal class ExampleBST : ExampleBase
    {

        private int[] Random {get; set;}
        
        public ExampleBST(int[] random) 
        {
            Random = random;
        }

        public void RunProblem()
        {
            TreeNode? root = null;

            foreach(int val in Random)
            {
                root = Insert(root, val);
            }
        }

        public TreeNode Insert(TreeNode? root, int value){

            if(root == null)
                return new TreeNode(value);

            if(value < root.Value)
                root.Left = Insert(root.Left, value);
            else
                root.Right = Insert(root.Right, value);

            return root;
        }
   }
}