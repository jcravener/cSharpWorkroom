using GamesFunction.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesFunction.Models
{
    public class PlayerCard
    {
        public PlayerCard(Player player)
        {
            TeamName = player.Team.ToString();
            EmailAddress = player.Email;
            First = player.FirstName;
            Last = player.LastName;
            CourseHandicap = GetCourseHandicap(player.HandicapIndex, player.Gender, player.TeeBoxName);
            GrossScores = player.GrossScores;
            NetScores = GetNetScore(CourseHandicap);
            GrossTotal = GrossScores.Sum();
            NetTotal = NetScores.Sum();
        }

        public PlayerCard()
        {
        }

        [JsonProperty(PropertyName = "teamName", Required = Required.Always)]
        public string TeamName { get; set; }
        [JsonProperty(PropertyName = "emailAddress", Required = Required.Always)]
        public string EmailAddress { get; set; }
        [JsonProperty(PropertyName = "first", Required = Required.Always)]
        public string First { get; set; }
        [JsonProperty(PropertyName = "last", Required = Required.Always)]
        public string Last { get; set; }
        [JsonProperty(PropertyName = "courseHandicap", Required = Required.Always)]
        public int CourseHandicap { get; set; }
        [JsonProperty(PropertyName = "grossScores", Required = Required.Always)]
        public int[] GrossScores { get; set; }
        [JsonProperty(PropertyName = "netScores", Required = Required.Always)]
        public int[] NetScores { get; set; }
        [JsonProperty(PropertyName = "grossTotal", Required = Required.Always)]
        public int GrossTotal { get; set; }
        [JsonProperty(PropertyName = "netTotal", Required = Required.Always)]
        public int NetTotal { get; set; }

        private int GetCourseHandicap(double handicapIndex, Gender gender, string teeBoxName)
        {
            TeeBox teeBox = TeeBoxes.Adarra[gender.ToString()][teeBoxName];
            double chc =  ((handicapIndex * (teeBox.Slope / 113)) + (teeBox.Rating - (double)teeBox.Par));

            return Convert.ToInt32(chc);
        }

        public int[] GetNetScore(int courseHandicap)
        {
            int[] netScore = new int[18];
            GrossScores.CopyTo(netScore, 0);

            for (int i = 0; i < (int)courseHandicap; i++)
            {
                var index = i;

                if (i > 17)
                {
                    index = i - 18;
                }

                netScore[AldarraHandicap.Holes[index] - 1]--;
            }

            return netScore;
        }

    }
}
