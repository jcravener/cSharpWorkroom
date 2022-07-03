// See https://aka.ms/new-console-template for more information

int[] nums = { 1, 3, 5, 6 };
int[] targets = { 5, 2, 7, 4, 77, 0};

Solution Solution = new Solution();

foreach(int t in targets)
{
    Console.WriteLine($"target: {t}, output: {Solution.SearchInsert(nums, t)}");
}

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        if(target < nums[0])
        {
            return 0;
        }

        if(target > nums[nums.Length-1])
        {
            return nums.Length;
        }
                
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == target)
            {
                return i;
            }

            if (nums[i] > target)
            {
                return i;
            }

        }

        return nums.Length;
    }
}