using System;
using System.Collections.Generic;
using System.Text;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = { "flower", "flow", "flight" };
            //string[] a = { "cir", "car"};

            Console.WriteLine(LongestCommonPrefix(a));
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            var sb = new StringBuilder();
            char row;
            int shortest = strs[0].Length;

            foreach (string st in strs)
            {
                if (st.Length < shortest)
                {
                    shortest = st.Length;
                }
            }

            for(int i = 0; i < shortest; i++)
            {
                row = strs[0][i];

                for (int j = 0; j < strs.Length; j++)
                {
                    if(!row.Equals(strs[j][i]))
                    {
                        return sb.ToString();
                    }
                }

                sb.Append(row);
            }

            return sb.ToString();
        }
    }
}
