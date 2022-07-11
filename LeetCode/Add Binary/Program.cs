// See https://aka.ms/new-console-template for more information


string a = "11";
string b = "1111";

Solution solution = new Solution();

Console.WriteLine(solution.AddBinary(a,b));


public class Solution
{
    public string AddBinary(string a, string b)
    {
        string big = a;
        string small = b;

        if(b.Length > a.Length)
        {
            big = b;
            small = a;
        }

        int max = big.Length - small.Length;

        for(int i = 0; i < max; i++)
        {
            small = "0" + small;
        }

        bool carry = false;
        string answer = "";

        for(int i = big.Length-1; i >= 0; i--)
        {
            if (big[i].Equals('0') && small[i].Equals('0'))
            {
                if (carry)
                {
                    answer = "1" + answer;
                    carry = false;
                }
                else
                {
                    answer = "0" + answer;
                }
            }
            else if(big[i].Equals('1') && small[i].Equals('1'))
            {
                if (carry)
                {
                    answer = "1" + answer;
                }
                else
                {
                    answer = "0" + answer;
                    carry = true;
                }
            }
            else
            {
                if (carry)
                {
                    answer = "0" + answer;
                    carry = true;
                }
                else
                {
                    answer = "1" + answer;
                }
            }
        }

        if (carry)
        {
            answer = "1" + answer;
        }

        return answer;
    }
}