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
            BindMatchResults();
            Log = log;
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
                        Team[team].MatchResult.Add(match, new GameResult());
                    }
                }
            }
        }

        //private void BindMatch()
        //{
        //    GameResult = new Dictionary<string, GameResult>();
            
        //    foreach(var match in Matches)
        //    {
        //        GameResult.Add(match, new GameResult());
        //    }
        //}


        //public void GetResluts()
        //{
        //    Dictionary<string, Team> _match = new Dictionary<string, Team>();
        //    List<string> names = new List<string>();
        //    Dictionary<string, GameResult> result = new Dictionary<string, GameResult>();

        //    foreach(var teamName in Matches)
        //    {
        //        var results = from team in Teams
        //                      where team.Name.Equals(teamName)
        //                      select team;
        //        _match[teamName] = results.FirstOrDefault();
        //        names.Add(teamName);
        //    }

        //    if(_match.Count != 2)
        //    {
        //        Log.LogError($"_match count of {_match.Count} in TeamResults.GetResluts is greater then 2.  Expecting only 2.");
        //        throw new Exception();
        //    }
            
        //    for(int i = 0; i < _match[names[0]].TeamScores.Count; i++)
        //    {
        //        if(_match[names[0]].TeamScores[i] > _match[names[0]].TeamScores[i])
        //        {
        //            if (!result.ContainsKey(names[0]))
        //            {
        //                result[names[0]] = new GameResult
        //                {
        //                    Match = "MatchName",
        //                    Front = 0,
        //                    Back = 0,
        //                    Eighteen = 0,
        //                    HolesWon = new List<int>()
        //                };                          
        //            }
        //            result[names[0]].HolesWon.Add(i);
        //        } 
        //        else if(_match[names[0]].TeamScores[i] < _match[names[0]].TeamScores[i])
        //        {

        //        }
        //        else
        //        {
        //            // tie
        //        }
        //    }            
        //}
    }
}
