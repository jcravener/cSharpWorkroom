using GamesFunction.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Models
{
    public class Player : Golfer
    {
        [JsonProperty(PropertyName = "teamName", Required = Required.Always)]
        public TeamName Team { get; set; }
        public DateTime Date { get; set; }
        public string CourseName { get; set; }
        [JsonProperty(PropertyName = "teeBoxName", Required = Required.Always)]
        public string TeeBoxName { get; set; }

        public double GetCourseHandicap()
        {
            var teeBox = TeeBoxes.Adarra[Gender.ToString()][TeeBoxName];
            var handi = ((HandicapIndex * (teeBox.Slope / 113)) + (teeBox.Rating - teeBox.Par));
            return handi;
        }
    }
}
