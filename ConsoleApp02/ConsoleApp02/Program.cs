using System;
using System.Linq;

namespace ConsoleApp02
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string[] names = new string[8] { "john", "beth", "london", "jane", "windsor", "elise", "ann", "harold" };

            myObj[] mos = new myObj[names.Length]; 

            for(int i = 0; i < names.Length; i++)
            {
                mos[i] = new myObj(Convert.ToString(rnd.Next(1, names.Length)), util.CapFirstLetter(names[i]));
            }

            int cnt = 0;            
            foreach(var o in mos.OrderBy(x => x.dtstamp))
            {
                if(cnt == 0)
                {
                    Console.WriteLine($"{o.dtstamp} {o.name}");
                }
                if(cnt == mos.Length - 1)
                {
                    Console.WriteLine($"{o.dtstamp} {o.name}");
                }
                cnt++;
            }
        }
    }

    class myObj
    {
        private string dtSuffix = "2020-10-";
        public DateTime dtstamp;
        public string name;

        public myObj(string s, string n)
        {
            this.dtstamp = DateTime.Parse(this.dtSuffix + s);
            this.name = n;
        }
    }

    static class util
    {
        public static string CapFirstLetter(string s)
        {
            if(s[0] >= 97 && s[0] <= 123)
            {
                s = Convert.ToChar(s[0] - 32) + s.Substring(1);                
            }
            return s;
        }
    }
}
