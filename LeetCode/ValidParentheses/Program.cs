using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ValidParentheses
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

            Console.WriteLine(IsValid(s).ToString());
        }

        public static char GetParenType(char p)
        {

            if (p.Equals('(') || p.Equals(')'))
            {
                return 'p';
            }
            if (p.Equals('[') || p.Equals(']'))
            {
                return 's';
            }
            if (p.Equals('{') || p.Equals('}'))
            {
                return 'c';
            }

            return '0';
        }

        public static bool IsClosed(char c)
        {
            
            if(c.Equals(')') || c.Equals(']') || c.Equals('}'))
            {
                return true;
            }

            return false;
        }

        public static bool IsValid(string s)
        {
            if (s.Length % 2 != 0 || IsClosed(s[0]) || (! IsClosed(s[^1])))
            {
                return false;
            }

            Stack<char> stk = new Stack<char>();

            foreach(char c in s)
            {
                if(IsClosed(c))
                {                    
                    if( stk.Count == 0 || ( !GetParenType(stk.Pop()).Equals(GetParenType(c)) ) )
                    {
                        return false;
                    }
                }
                else
                {
                    stk.Push(c);
                }
            }

            if(stk.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
