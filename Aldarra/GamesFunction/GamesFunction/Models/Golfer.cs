using GamesFunction.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class Golfer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender { get; set; }
        public double HandicapIndex { get; set; }
    }
}
