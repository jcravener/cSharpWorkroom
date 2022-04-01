using GamesFunction.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesFunction.Models
{
    public class Player : Golfer
    {
        [JsonProperty(PropertyName = "teamName", Required = Required.Always)]
        public TeamName Team { get; set; }
        
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "courseName", Required = Required.Always)] 
        public string CourseName { get; set; }
        
        [JsonProperty(PropertyName = "teeBoxName", Required = Required.Always)]
        public string TeeBoxName { get; set; }
        
        [JsonProperty(PropertyName = "grossScore", Required = Required.Always)]
        public int[] GrossScores { get; set; } = new int[18];
    }
}
