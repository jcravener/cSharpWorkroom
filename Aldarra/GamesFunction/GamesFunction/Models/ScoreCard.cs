using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class ScoreCard
    {
        public double Slope { get; set; }
        public double Rating { get; set; }

        public int[] handicap { get; set; } = new int[18];
    }
}
