using GamesFunction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesFunction.Helpers
{
    public class Team
    {
        public Team(string teamName, List<PlayerCard> playerCards)
        {
            Name = teamName;
            BindPlayerScores(playerCards);
            BindTeamScores();
        }

        public string Name { get; set; }
        private Dictionary<string, Scores> PlayerScores { get; set; } = new Dictionary<string, Scores>();
        public List<int> TeamScores { get; private set; } = new List<int>();
        
        public Dictionary<string, GameResult> MatchResult { get; set; }
        private int HoleCount { get; set;  }


        private void BindPlayerScores(List<PlayerCard> playerCards)
        {            
            foreach(var card in playerCards)
            {
                if (card.TeamName.Equals(Name))
                {                    
                    PlayerScores[card.EmailAddress] = new Scores(gross: card.GrossScores, net: card.NetScores);

                    if(HoleCount == 0)
                    {
                        HoleCount = card.GrossScores.Length;
                    }
                }
            }
        }

        private void BindTeamScores()
        {
            for(int i = 0; i < HoleCount; i++)
            {
                TeamScores.Add(GetTeamScore(i));
            }
        }
        
        private int GetTeamScore(int hole)
        {
            List<Score> gross = new List<Score>();
            List<Score> net = new List<Score>();

            foreach (var email in PlayerScores.Keys)
            {
                gross.Add(new Score(email, PlayerScores[email].Gross[hole])); ;
                net.Add(new Score(email, PlayerScores[email].Net[hole])); ;
            }

            gross = gross.OrderBy(x => x.Value).ToList();
            net = net.OrderBy(x => x.Value).ToList();

            if(gross[0].Email != net[0].Email)
            {
                return gross[0].Value + net[0].Value;
            }
            else
            {
                int value = gross[0].Value + net[1].Value;

                if(value < gross[1].Value + net[0].Value)
                {
                    return value;
                }
                else
                {
                    return gross[1].Value + net[0].Value;
                }
            }
        }

        private class Score
        {
            public Score(string email, int value)
            {
                Email = email;
                Value = value;
            }

            public string Email { get; set; }
            public int Value { get; set; }
        }
    }
}
