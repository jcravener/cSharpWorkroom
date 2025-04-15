using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Util
{
    public class TreeNode
    {
        public int Value { get; set; }

        public TreeNode? Left { get; set; }

        public TreeNode? Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public void InsertLeft(TreeNode node, int val)
        {
            if (node.Left == null)
            {
                node.Left = new TreeNode(val);
            }
            else
            {
                InsertLeft(node.Left, val);
            }
        }

        public void InsertRight(TreeNode node, int val)
        {
            if (node.Right == null)
            {
                node.Right = new TreeNode(val);
            }
            else
            {
                InsertLeft(node.Right, val);
            }
        }
    }
}
