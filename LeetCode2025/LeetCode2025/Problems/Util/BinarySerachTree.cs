using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Util
{
    public class BinarySerachTree
    {
        public TreeNode? Root { get; set; }

        public BinarySerachTree()
        {
            Root = null;
        }
        
        public void Insert(int? val)
        {
            Root = InsertNode(Root, val);
        }

        private TreeNode? InsertNode(TreeNode? root, int? val)
        {
            if (val == null) return root;
            
            if (root == null)
            {
                root = new TreeNode((int)val);
                return root;
            }

            if(val < root.Value)
            {
                root.Left = InsertNode(root.Left, val);
            }
            else if(val > root.Value)
            {
                 root.Right = InsertNode(root.Right, val);
            }

            return root;
        }
    }
}
