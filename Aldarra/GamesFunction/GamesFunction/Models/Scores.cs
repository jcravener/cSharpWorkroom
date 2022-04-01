using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class Scores
    {
        public Scores(int[] gross, int[] net)
        {
            Gross = gross;
            Net = net;
        }

        public int[] Gross { get; set; }
        public int[] Net { get; set; }
    }
}
