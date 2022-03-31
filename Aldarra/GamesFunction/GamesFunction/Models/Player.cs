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
        [JsonProperty(PropertyName = "score", Required = Required.Always)]
        public int[] score { get; set; } = new int[18];

        public double GetCourseHandicap()
        {
            var teeBox = TeeBoxes.Adarra[Gender.ToString()][TeeBoxName];
            var handi = ((HandicapIndex * (teeBox.Slope / 113)) + (teeBox.Rating - teeBox.Par));
            return handi;
        }

        public int[] GetNetScore()
        {
            int[] netScore = new int[18];
            score.CopyTo(netScore, 0);
            
            var courseHandicap = GetCourseHandicap();

            for(int i = 0; i < (int)courseHandicap; i++)
            {
                var index = i;
                
                if(i > 17)
                {
                    index = i - 18;
                }
                
                netScore[AldarraHandicap.Holes[index]-1]--;
            }

            return netScore;
        }
    }
}
