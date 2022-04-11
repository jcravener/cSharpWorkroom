using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class GameResult
    {
        public string Match { get; set; }
        public int Front { get; set; }
        public int Back { get; set; }
        public int Eighteen { get; set; }
        public List<int> HolesWon { get; set; }
        public List<int> HolesTied { get; set; }
    }
}
