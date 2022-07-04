using System;

namespace Implement_strStr
{
    class Program
    {
        static void Main()
        {
            //string h = "mississ";
            string h = "mississippi";
            string n = "issip";
            
            Console.WriteLine(StrStr(h, n).ToString());
        }

        // This solution doesn't work.  

        // Another approach would be to check substrings.
        // 1) once you find maching first chars,
        // 2) compare the substring in haystack starting at the first found index and ending with an offset of needle.Length
        // 3) If they don't match, start over - but always check whether the length of the raminaing substring is >= needle

        public static int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle) || haystack.Equals(needle))
            {
                return 0;
            }

            if(needle.Length > haystack.Length)
            {
                return -1;
            }

            //char[] h = haystack.ToCharArray();
            //char[] n = needle.ToCharArray();

            for(int i = 0; i < haystack.Length; i++)
            {
                if(haystack[i] == needle[0])
                {
                    if (haystack.Length - i >= needle.Length)
                    {
                        if (needle.Equals(haystack.Substring(i, needle.Length)))
                        {
                            return i;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return -1;
        }
    }
}
