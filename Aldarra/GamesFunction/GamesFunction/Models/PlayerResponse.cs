using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class PlayerResponse
    {
        public string Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseHandicap { get; set; }
        public int GrossScoreTotal { get; set; }
        public int NetScoreTotal { get; set; }
        public int[] NetScore { get; set; }
    }
}
