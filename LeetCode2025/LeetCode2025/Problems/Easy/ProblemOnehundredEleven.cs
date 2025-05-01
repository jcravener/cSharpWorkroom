using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    public class ProblemOnehundredEleven : ProblemBase
    {
        public TreeNode Root { get; set; }
        
        public ProblemOnehundredEleven(int example)
        {
            switch (example)
            {
                case 1:
                    Root = new TreeNode(3);
                    Root.Left = new TreeNode(9);
                    Root.Right = new TreeNode(20);
                    Root.Right.Left = new TreeNode(15);
                    Root.Right.Right = new TreeNode(7);
                    break;
                case 2:
                    Root = new TreeNode(2);
                    Root.Right = new TreeNode(3);
                    break;
                default:
                    throw new Exception($"Example {example} unknown.");
            }
        }
    }
}
