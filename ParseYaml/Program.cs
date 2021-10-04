using System;
using System.IO;
using System.Text.RegularExpressions;


namespace ParseYaml
{
    class Program
    {
        static void Main(string[] args)
        {
            String usage = $"usage: {System.AppDomain.CurrentDomain.FriendlyName} -y /path/to/yaml/file | -j /path/to/yaml/file";
            Regex pat = new Regex(@"^\-[yj]");
            Match m = pat.Match(args[0]);

            if (args.Length.Equals(0))
            {
                Console.Error.Write(usage);
                Environment.Exit(1);
            }

            String txt;
            String output;

            if (m.Success)
            {
                
                try
                {
                    txt = File.ReadAllText($@"{args[1]}");
                }
                catch(Exception ex)
                {
                    throw new Exception($"Had a problem reading file: {args[1]}");
                }
                
                var reader = new StringReader(txt);

                if (args[0].Equals("-y"))
                {
                    output = Convert.ToJson(reader);
                    Console.Write(output);
                }
                else
                {
                    output = Convert.toYaml(txt);
                    Console.Write(output);
                }
            }
            else
            {
                Console.Error.Write(usage);
                Environment.Exit(1);
            }





        }
    }
}
