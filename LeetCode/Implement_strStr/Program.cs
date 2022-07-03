using System;

namespace Implement_strStr
{
    class Program
    {
        static void Main()
        {
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
            int firstIndex = -1;

            if (string.IsNullOrEmpty(needle) || haystack.Equals(needle))
            {
                return 0;
            }

            if(needle.Length > haystack.Length)
            {
                return -1;
            }

            char[] h = haystack.ToCharArray();
            char[] n = needle.ToCharArray();

            for(int i = 0; i < haystack.Length; i++)
            {                                
                if(h[i] == n[0]) // we found first char, now check the rest
                {
                    firstIndex = i;

                    if(needle.Length == 1)
                    {
                        return firstIndex;
                    }

                    for(int j = 1; j < n.Length; j++)
                    {
                        if(i+j < h.Length)
                        {
                            return firstIndex;
                        }
                        
                        if(n[j] != h[i + j])
                        {
                            firstIndex = -1;
                            continue;
                        }
                    }
                }
            }

            return firstIndex;
        }
    }
}
