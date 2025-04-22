using LeetCode2025.Problems.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode2025.Problems.Easy
{
    public class ProblemOnehundredEight : ProblemBase
    {
        public int[] Nums { get; set; }

        TreeNode Root { get; set; }

        public ProblemOnehundredEight(int[] nums)
        {
            Nums = nums;
        }

        public void RunProblem()
        {
            Root = BallancedTree(Nums, 0, Nums.Length - 1);
            
            Console.WriteLine(ToString(Nums));
        }

        public TreeNode? BallancedTree(int[] nums, int start, int end)
        {
            if (start > end) return null;
            if (start < 0 || end >= nums.Length) return null;
            
            int mid = start + (end - start) / 2;
            
            var node = new TreeNode(nums[mid]);

            node.Left = BallancedTree(nums, start, mid - 1);
            node.Right = BallancedTree(nums, mid + 1, end);

            return node;
        }
    }
}
