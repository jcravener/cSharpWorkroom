// See https://aka.ms/new-console-template for more information

TreeNode root = new TreeNode(1, null, null);
TreeNode two = new TreeNode(2, null, null);
TreeNode three = new TreeNode(3, null, null);

root.Right = two;
two.Left = three;

Solution solution = new Solution();

foreach(int i in solution.InorderTraversal(root))
{
    Console.WriteLine(i);
}


// Below is solution one from Leetcode:

public class TreeNode
{
    public int Val { get; set; }
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }
    public TreeNode(int val, TreeNode? left, TreeNode? right)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}

public class Solution
{
    public IList<int> InorderTraversal(TreeNode? root)
    {
        List<int> res = new List<int>();
        Helper(root, res);
        return res;
    }

    public void Helper(TreeNode? root, IList<int> res)
    {
        if(root != null)
        {
            Helper(root.Left, res);
            res.Add(root.Val);
            Helper(root.Right, res);
        }
    }
}
