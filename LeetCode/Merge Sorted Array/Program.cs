// See https://aka.ms/new-console-template for more information

int[] nums1 = { 1, 2, 3, 0, 0, 0 };
int m = 3;
int[] nums2 = { 2, 5, 6 };
int n = 3;


for(int i = 0; i < n; i++)
{    
    nums1[m+i] = nums2[i];
}

Array.Sort(nums1);

for(int i = 0; i < nums1.Length; i++)
{
    Console.WriteLine(nums1[i]);
}