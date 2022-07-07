// See https://aka.ms/new-console-template for more information


string a = "11";
string b = "111100";

Solution solution = new Solution();

Console.WriteLine(solution.AddBinary(a,b));


public class Solution
{
    public string AddBinary(string a, string b)
    {
        int max = 0;

        if (a.Length > b.Length)
        {
            max = a.Length - b.Length;

            for (int i = 0; i < max; i++)
            {
                b = "0" + b;
            }
        }
        if (a.Length < b.Length)
        {
            max = b.Length - a.Length;

            for (int i = 0; i < max; i++)
            {
                a = "0" + a;
            }
        }

        int carry = 0;
        string rt = "";

        for(int i = 0; i < a.Length; i++)
        {
            if (a[i].Equals("1") && b[i].Equals("1"))
            {
                carry = 1;
                rt = rt + "0";
            }
        }
    }
}