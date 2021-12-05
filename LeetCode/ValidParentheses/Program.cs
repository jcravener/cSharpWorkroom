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
                [System.Environment.Exit(1);
            }

            string s = args[0];
        }

        public static bool IsValid(string s)
        {
            Dictionary<string, int> map = new Dictionary<string, int>()
            {
                { "paren", 0},
                { "square", 0},
                { "curly", 0}
            };



            Regex parenRx = new Regex(@"[\(\)]", RegexOptions.Compiled);
            Regex squareRx = new Regex(@"[\[\]]", RegexOptions.Compiled);
            Regex curlyRx = new Regex(@"[\{\}]", RegexOptions.Compiled);

            foreach(char c in s)
            {
                if( c.Equals('(') || c.Equals(')'))
                {
                    map["paren"] += 1
                }
            }

            
            return false;
        }
    }
}
