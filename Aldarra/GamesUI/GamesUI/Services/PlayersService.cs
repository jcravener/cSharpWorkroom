using GamesUI.Constants;
using GamesUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesUI.Services
{
    public class PlayersService
    {
        private static readonly List<Player> Players = new List<Player>
        {
            { new Player
                {
                    Email = "jcravener@hotmail.com",
                    FirstName = "John",
                    LastName = "Cravener",
                    Gender = Gender.Male,
                    HandicapIndex = 8.0,
                    Team = TeamName.A,
                    CourseName = "Aldarra",
                    TeeBoxName = "Member",
                    GrossScores = new int[] { 4, 4, 6, 4, 5, 3, 6, 6, 9, 5, 5, 5, 4, 5, 4, 5, 4, 5 }
                }
            },
            { new Player
                {
                    Email = "fred@hotmail.com",
                    FirstName = "Fred",
                    LastName = "Cravener",
                    Gender = Gender.Male,
                    HandicapIndex = 8.7,
                    Team = TeamName.B,
                    CourseName = "Aldarra",
                    TeeBoxName = "Member",
                    GrossScores = new int[] { 4, 2, 6, 4, 5, 4, 6, 6, 7, 5, 5, 6, 4, 3, 4, 5, 4, 5 }
                }
            },
            { new Player
                {
                    Email = "dan@hotmail.com",
                    FirstName = "Dan",
                    LastName = "Cravener",
                    Gender = Gender.Male,
                    HandicapIndex = 9.7,
                    Team = TeamName.C,
                    CourseName = "Aldarra",
                    TeeBoxName = "Member",
                    GrossScores = new int[] { 4, 2, 5, 7, 5, 4, 3, 6, 4, 5, 7, 5, 4, 4, 4, 5, 6, 6 }
                }
            }
        };
        public Task<List<Player>> GetPlayers(DateTime gameDate)
        {
            foreach (var player in Players)
            {
                player.Date = gameDate;
            }

            return Task.FromResult(Players);
        }
    }
}
