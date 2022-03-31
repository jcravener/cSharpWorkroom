using GamesFunction.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class TeeBox : GolfClub
    {
        public TeeBox(string name, int par, string tee, int slope, double rating, Gender gender) : base(name, par)
        {
            Tee = tee;
            Slope = slope;
            Rating = rating;
            Gender = gender;
        }

        public string Tee { get; set; }
        public double Slope { get; set; }
        public double Rating { get; set; }
        public Gender Gender { get; set; }
    }
}
