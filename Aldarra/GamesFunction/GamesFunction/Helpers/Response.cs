using GamesFunction.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesFunction.Helpers
{
    public class Response
    {
        public PlayerResponse GetPlayerResponse(Player player)
        {
            return new PlayerResponse
            {
                Team = player.Team.ToString(),
                FirstName = player.FirstName,
                LastName = player.LastName,
                CourseHandicap = (int)player.GetCourseHandicap()
            };
        }
    }
}
