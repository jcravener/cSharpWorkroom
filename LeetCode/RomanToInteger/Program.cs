using System;
using System.Collections.Generic;

namespace RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Input not provided.");
                System.Environment.Exit(1);
            }

            string s = args[0];
            int numb = RomanToInt(s);

            Console.WriteLine($"Got: {numb.ToString()}");
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            char[] chArr = s.ToCharArray();
            Array.Reverse(chArr);
            Stack<char> chStk = new Stack<char>(chArr);
            int rt = 0;

            char chtmp;

            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);

            if(chStk.Count == 1)
            {
                return map[chStk.Pop()];
            }

            while(chStk.Count > 0)
            {
                if((chStk.Peek().Equals('I') || chStk.Peek().Equals('X') || chStk.Peek().Equals('C')) && chStk.Count > 1)
                {
                    chtmp = chStk.Pop();

                    if (chtmp.Equals('I') && (chStk.Peek().Equals('V') || chStk.Peek().Equals('X')))
                    {
                        rt += map[chtmp] + map[chStk.Pop()] - 2;
                    }
                    else if (chtmp.Equals('X') && (chStk.Peek().Equals('L') || chStk.Peek().Equals('C')))
                    {
                        rt += map[chtmp] + map[chStk.Pop()] - 20;
                    }
                    else if (chtmp.Equals('C') && (chStk.Peek().Equals('D') || chStk.Peek().Equals('M')))
                    {
                        rt += map[chtmp] + map[chStk.Pop()] - 200;
                    }
                    else
                    {
                        rt += map[chtmp];
                    }
                }
                else
                {
                    rt += map[chStk.Pop()];
                }
            }
            
            return rt;
        }
    }
}
