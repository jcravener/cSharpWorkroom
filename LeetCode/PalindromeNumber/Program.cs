using System;

namespace PalindromeNumber
{
    class Program
    {
        static void Main(string[] nums)
        {
            string num;
            int numInt;

            if (nums.Length > 0)
            {
                num = nums[0];

                try
                {
                    numInt = Int32.Parse(num);

                    if (IsPalindrome(numInt))
                    {
                        Console.Write("Success: ");
                    }
                    else
                    {
                        Console.Write("Failure: ");
                    }

                    Console.WriteLine(num);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    System.Environment.Exit(1);
                }

            }
            else
            {
                Console.WriteLine("No input provided.");                
                System.Environment.Exit(1);
            }
        }

        public static bool IsPalindrome(int x)
        {
            string xStr;
            char[] xCha;
            int mid;
            
            if(x < 0)
            {
                return false;
            }
            else if (x < 10) 
            {
                return true;
            }

            try
            {
                xStr = x.ToString();
            }
            catch
            {
                return false;
            }

            xCha = xStr.ToCharArray();

            if(xCha.Length == 1)
            {
                return true;
            }

            mid = xCha.Length / 2;
            int j = xCha.Length - 1;

            for(int i = 0; i <= mid; i++)
            {
                if(!xCha[i].Equals(xCha[j]))
                {
                    return false;
                }
                j--;
            }

            return true;
        }
    }
}
