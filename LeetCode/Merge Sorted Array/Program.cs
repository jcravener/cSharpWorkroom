// See https://aka.ms/new-console-template for more information

int[] nums1 = { 1, 2, 3, 0, 0, 0 };
int[] nums2 = { 2, 5, 6 };

int max = nums1.Length;

for(int i = nums1.Length - 1; i >= nums2.Length; i--)
{    
    nums1[i] = nums2[i - nums2.Length];
}

Array.Sort(nums1);

for(int i = 0; i < max; i++)
{
    Console.WriteLine(nums1[i]);
}