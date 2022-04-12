using GamesFunction.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamesFunction.Helpers
{
    public class Utility
    {
        public Utility()
        {
        }

        public Utility(ILogger log)
        {
            Log = log;
        }

        public ILogger Log { get; set; }

        public List<string> GetAllPairs(List<string> teams)
        {
            StringBuilder sb = new StringBuilder();

            List<string> vs = new List<string>();

            foreach(string c in teams)
            {                
                foreach(string cc in teams)
                {
                    sb.Clear();
                    sb.Append(c);

                    if(c != cc)
                    {
                        sb.Append(cc);

                        char[] characters = sb.ToString().ToCharArray();
                        Array.Sort(characters);

                        sb.Clear();
                        sb.Append(characters);

                        if (!vs.Contains(sb.ToString()))
                        {
                            vs.Add(sb.ToString());
                            sb.Clear();
                        }                  
                    }
                }
            }

            return vs;
        }

        public List<string> GetTeamNames(List<PlayerCard> playerCards)
        {
            var results = from PlayerCard in playerCards
                          select PlayerCard.TeamName;

            return results.Distinct().ToList();
        }

        public List<Skin> GetSkins(List<PlayerCard> playerCards)
        {
            List<Skin> skins = new List<Skin>();

            int holeCount = playerCards[0].GrossScores.Length;

            int scoreCount = 0;
            Skin currentSkin = new Skin();

            for (int hole = 0; hole < holeCount; hole++)
            {
                for(int card = 0; card < playerCards.Count; card++)
                {
                    if(card == 0)
                    {
                        currentSkin.Team = playerCards[card].EmailAddress;
                        currentSkin.Email = playerCards[card].EmailAddress;
                        currentSkin.FirstName = playerCards[card].First;
                        currentSkin.LastName = playerCards[card].Last;
                        currentSkin.Score = playerCards[card].GrossScores[hole];
                        scoreCount = 1;
                        continue;
                    }

                    if(scoreCount == 1 && playerCards[card].GrossScores[hole] < currentSkin.Score)
                    {
                        currentSkin.Team = playerCards[card].EmailAddress;
                        currentSkin.Email = playerCards[card].EmailAddress;
                        currentSkin.FirstName = playerCards[card].First;
                        currentSkin.LastName = playerCards[card].Last;
                        currentSkin.Score = playerCards[card].GrossScores[hole];
                        scoreCount = 1;
                    }

                    if(playerCards[card].GrossScores[hole] == currentSkin.Score)
                    {
                        card = playerCards.Count;
                    }
                }
            }


            return skins;
        }
    }
}
