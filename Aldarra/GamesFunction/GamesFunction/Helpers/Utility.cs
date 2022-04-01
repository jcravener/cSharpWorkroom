using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Helpers
{
    public class Utility
    {
        public List<string> GetAllPairs(string teams)
        {
            StringBuilder sb = new StringBuilder();

            List<string> vs = new List<string>();

            foreach(char c in teams)
            {                
                foreach(char cc in teams)
                {
                    sb.Clear();
                    sb.Append(c);

                    if(c != cc)
                    {
                        sb.Append(cc);

                        char[] characters = sb.ToString().ToCharArray();
                        Array.Sort(characters);

                        sb.Clear();
                        sb.Append(characters);

                        if (!vs.Contains(sb.ToString()))
                        {
                            vs.Add(sb.ToString());
                            sb.Clear();
                        }                  
                    }
                }
            }

            return vs;
        }
    }
}
