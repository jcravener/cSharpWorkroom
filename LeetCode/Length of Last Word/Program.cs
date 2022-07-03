// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

string s = "   fly me   to   the moon  ";

Solution Solution = new Solution();

Console.WriteLine(Solution.LengthOfLastWord(s));

public class Solution
{   
    public int LengthOfLastWord(string s)
    {
        if(s.Length == 0)
        {
            return 0;
        }

        string[] words = Regex.Split(s.Trim(), @"\s+");

        return words[words.Length - 1].Length;
    }
}
