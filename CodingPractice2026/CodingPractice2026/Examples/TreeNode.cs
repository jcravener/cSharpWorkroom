using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice2026.Examples
{
    public class TreeNode
    {
        public int Value {  get; }

        public TreeNode? Left { get; set;  }

        public TreeNode? Right { get; set;  }

        public TreeNode(int val, TreeNode? left = null, TreeNode? right = null)
        {
            Value = val;
            Left = left;
            Right = right;
        }
    }
}
