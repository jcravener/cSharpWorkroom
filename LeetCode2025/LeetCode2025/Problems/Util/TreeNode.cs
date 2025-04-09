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

        public TreeNode(int value, TreeNode? left, TreeNode? right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
