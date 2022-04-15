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

        public List<SkinResult> GetSkins(List<PlayerCard> playerCards)
        {

            int holes = playerCards[0].GrossScores.Length;
            List<Skin>[] skinMatrix = new List<Skin>[holes];

            List<SkinResult> skinResults = new List<SkinResult>();
            
            for(int i = 0; i < holes; i++)
            {
                //skinMatrix[i] = new List<Skin>();
                var skinList = new List<Skin>();

                foreach (PlayerCard playerCard in playerCards)
                {                                        
                    skinList.Add(new Skin
                    {
                        Team = playerCard.TeamName,
                        Email = playerCard.EmailAddress,
                        FirstName = playerCard.First,
                        LastName = playerCard.Last,
                        Score = playerCard.GrossScores[i],
                    });
                }

                var result = from skin in skinList
                             orderby skin.Score
                             select skin;

                skinMatrix[i] = result.ToList();

                if(result.ToList().Count > 1 && result.ToList()[0].Score != result.ToList()[1].Score)
                {
                    skinResults.Add(new SkinResult
                    {
                        Team = result.ToList()[0].Team,
                        Email = result.ToList()[0].Email,
                        FirstName = result.ToList()[0].FirstName,
                        LastName = result.ToList()[0].LastName,
                        Score = result.ToList()[0].Score,
                        Hole = i
                    }); 
                }
            }

            return skinResults;
        }
    }
}
