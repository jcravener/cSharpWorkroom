using GamesFunction.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class Skin
    {
        public string Team { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Score { get; set; }
    }
}
