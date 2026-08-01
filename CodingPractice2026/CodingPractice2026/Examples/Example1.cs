using System;
using System.Text.RegularExpressions;

namespace CodingPractice2026.Examples
{
    internal class Example1 : ExampleBase
    {
        private string Input {get; set;}
        
        public Example1(string input) : base()
        {
            Input = input;
        }

        public void RunProblem()
        {
            foreach(var kv in parse_config(Input))
            {
                Console.WriteLine($"{kv.Key} {kv.Value}");
            }
        }


        // Invariants
        // 1. Only one key/value pair allowed per line
        // 2. Lowercase letteres only
        // 3. Values: integer -> int; boolean -> true/false; everything else -> string
        // 4. Ignore blank lines
        // 5. Fail fast on malformed inputs
        private Dictionary<string, object> parse_config(string str)
        {
            Dictionary<string, object> dict  = new();
            List<string> lst = new();

            foreach(var line in str.Split("\n"))
            {
                // Invariant #4
                if(string.IsNullOrWhiteSpace(line))
                    continue;

                string[] kv = line.Split("=");

                // Invariant #1, #5
                if( kv.Length != 2)
                    throw new Exception($"Only one key/value allowed on a line: {line}");

                string key = kv[0].Trim();
                string val = kv[1].Trim();

                // Invariant #2, #5
                if(!Regex.IsMatch(key, "^[a-z]+$"))
                    throw new Exception($"Key should be lowercase only: {line}");


                if(key.Length == 0 || val.Length == 0)
                    throw new Exception($"Blank keys or values are not allowed: {line}");

                // Invariant 3
                if(int.TryParse(val, out int intVal))
                {                    
                    dict.Add(key, intVal);
                }
                else if(bool.TryParse(val, out bool boolVal))
                {
                    dict.Add(key, boolVal);
                }
                else
                {
                    dict.Add(key, val);
                }                
            }

            return dict;
        }
   }
}
