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


        public static int StrStr(string haystack, string needle)
        {            
            // If needle is emty, return 0 by definition.  Or if needle equals hasytack retun the first index
            if (string.IsNullOrEmpty(needle) || haystack.Equals(needle))
            {
                return 0;
            }

            // If needle is longer than haystack it cannot be a substring.
            if(needle.Length > haystack.Length)
            {
                return -1;
            }

            // loop through each char of haystack looking for a match with the first char in needle            
            for(int i = 0; i < haystack.Length; i++)
            {
                //  If we find a char match between the first needle char, check wether the substring of equal length to needle is a string match
                if(haystack[i] == needle[0])
                {
                    //  Be sure we have the enough remaining hastack chars to equal the lengh of the needle
                    if (haystack.Length - i >= needle.Length)
                    {
                        if (needle.Equals(haystack.Substring(i, needle.Length)))
                        {
                            return i;
                        }
                    }
                    else // we dont have enough chars in the hasystach substring length so there is no way to match
                    {
                        break;
                    }
                }
            }
            return -1;
        }
    }
}
