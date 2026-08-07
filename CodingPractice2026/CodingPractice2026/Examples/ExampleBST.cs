using System;
using System.Text.RegularExpressions;

namespace CodingPractice2026.Examples
{
    internal class ExampleBST : ExampleBase
    {

        private int[] Random {get; set;}

        private List<int> List  = new();
        
        public ExampleBST(int[] random) 
        {
            Random = random;
        }

        public void RunProblem()
        {
            TreeNode? root = BuildTree();
            
            InOrderDFS(root);

            Console.WriteLine($"In-Order DFS:\n{string.Join(" ", List)}");

            List.Clear();

            PreOrderDFS(root);

            Console.WriteLine($"Pre-order DFS:\n{string.Join(" ", List)}");

            List.Clear();

            PostOrderDFS(root);

            Console.WriteLine($"Post-order DFS:\n{string.Join(" ", List)}");
        }

        private void InOrderDFS(TreeNode? root)
        {
            if(root == null)
                return;

            if(root.Left != null)
                InOrderDFS(root.Left);

            List.Add(root.Value);

            if(root.Right != null)
                InOrderDFS(root.Right);
        }

        private void PreOrderDFS(TreeNode? root)
        {
            if(root == null)
                return;
            
            List.Add(root.Value);

            if(root.Left != null)
                PreOrderDFS(root.Left);

            if(root.Right != null)
                PreOrderDFS(root.Right);
        }

        private void PostOrderDFS(TreeNode? root)
        {
            if(root == null)
                return;

            if(root.Left != null)
                PostOrderDFS(root.Left);
            
            if(root.Right != null)
                PostOrderDFS(root.Right);

            List.Add(root.Value);
        }

        public TreeNode? BuildTree()
        {
            TreeNode? root = null;

            foreach(int val in Random)
            {
                root = Insert(root, val);
            }

            return root;            
        }

        private TreeNode Insert(TreeNode? root, int value){

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