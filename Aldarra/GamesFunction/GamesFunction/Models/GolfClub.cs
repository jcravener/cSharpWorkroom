using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class GolfClub
    {
        public GolfClub(string name, int par)
        {
            Name = name;
            Par = par;
        }

        public string Name { get; set; }
        public int Par { get; set; }
    }
}
