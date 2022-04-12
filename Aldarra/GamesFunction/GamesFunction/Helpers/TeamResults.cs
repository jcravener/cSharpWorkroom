using GamesFunction.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesFunction.Helpers
{
    class TeamResults
    {
        public TeamResults(List<Team> teams, List<string> matches, ILogger log)
        {
            BindTeams(teams);
            Matches = matches;
            Log = log;
            BindMatchResults();
            CalulateMatchResults();
        }

        [JsonProperty(PropertyName = "team", Required = Required.Always)]
        public Dictionary<string, Team> Team { get; set; }
        [JsonProperty(PropertyName = "matches", Required = Required.Always)]
        public List<string> Matches { get; set; }
        [JsonIgnore]
        public ILogger Log { get; set; }
        //public Dictionary<string, GameResult> GameResult { get; set; }

        public void BindTeams(List<Team> teams)
        {
            Team = new Dictionary<string, Team>();
            
            foreach(var team in teams)
            {
                team.MatchResult = new Dictionary<string, GameResult>();                                                
                Team.Add(team.Name, team);
            }
        }

        public void BindMatchResults()
        {
            foreach( var team in Team.Keys)
            {
                foreach(var match in Matches)
                {
                    if (match.Contains(team))
                    {
                        Team[team].MatchResult.Add(match, new GameResult { Match = match, HolesWon = new List<int>(), HolesTied = new List<int>()});
                    }
                }
            }
        }
        public void CalulateMatchResults()
        {
            foreach(var team in Team.Keys)
            {
                foreach( var match in Team[team].MatchResult.Keys)
                {
                    var competitor = GetCompetitorName(match, team);
                    Log.LogInformation($"Calculating match {team} vs {competitor}");

                    for(int i = 0; i < Team[team].TeamScores.Count; i++)
                    {
                        if(Team[team].TeamScores[i] > Team[competitor].TeamScores[i])
                        {
                            Team[team].MatchResult[match].HolesWon.Add(i);

                            if(i <= 5)
                            {
                                Team[team].MatchResult[match].Front++;
                            }
                            else
                            {
                                Team[team].MatchResult[match].Back++;
                            }

                            Team[team].MatchResult[match].Eighteen++;
                        }
                        else if(Team[team].TeamScores[i] == Team[competitor].TeamScores[i])
                        {
                            Team[team].MatchResult[match].HolesTied.Add(i);
                        }
                    }
                }
            }
        }

        private string GetCompetitorName(string match, string team)
        {
            return match.Replace(team, null);
        }
    }
}
