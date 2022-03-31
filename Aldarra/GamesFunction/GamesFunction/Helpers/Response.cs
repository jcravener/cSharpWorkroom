using GamesFunction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesFunction.Helpers
{
    public class Response
    {
        public PlayerResponse GetPlayerResponse(Player player)
        {
            var playerResponse = new PlayerResponse
            {
                Team = player.Team.ToString(),
                FirstName = player.FirstName,
                LastName = player.LastName,
                CourseHandicap = (int)player.GetCourseHandicap(),
                GrossScoreTotal = player.score.Sum(),
                NetScore = player.GetNetScore()               
            };

            playerResponse.NetScoreTotal = playerResponse.NetScore.Sum();

            return playerResponse;
        }
    }
}
