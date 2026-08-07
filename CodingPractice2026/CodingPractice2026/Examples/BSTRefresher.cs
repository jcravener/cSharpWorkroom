using System;
using System.Text.RegularExpressions;

namespace CodingPractice2026.Examples
{
    internal class BSTRefresher : ExampleBase
    {        
        public BSTRefresher() : base()
        {
        }

        public void RunProblem()
        {
        }

        // Invariants
        // 1. ...
        // 2. ...
        private TreeNode Insert(TreeNode? root, int val)
        {
            if (root == null)
                return new TreeNode(val);

            if (val < root.Value)
                root.Left = Insert(root.Left, val);
            else
                root.Right = Insert(root.Right, val);
            
            return root;
        }
   }
}