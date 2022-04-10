using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using GamesFunction.Models;
using GamesFunction.Helpers;
using System.Web.Http;
using System.Collections.Generic;

namespace GamesFunction
{
    public static class Function1
    {
        [FunctionName("Players")]
        public static async Task<IActionResult> Players(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger Aldarra/Players endpoint processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            Utility util = new Utility();
            var teamNames = "ABCD";
            var allMatches = util.GetAllPairs(teamNames);

            List<Player> players;
            try
            {
                players = JsonConvert.DeserializeObject<List<Player>>(requestBody);
            }
            catch(Exception e)
            {
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }

            List<PlayerCard> playerCards = new List<PlayerCard>();

            foreach( var player in players )
            {
                playerCards.Add(new PlayerCard(player));
            }

            var uniqueTeamNames = util.GetTeamNames(playerCards);

            List<Team> teams = new List<Team>();

            foreach(var teamName in uniqueTeamNames)
            {
                teams.Add(new Team(teamName, playerCards));
            }

            var responseMessage = JsonConvert.SerializeObject(teams);
            //var responseMessage = JsonConvert.SerializeObject(playerCards);
            return new OkObjectResult(responseMessage);
        }

        [FunctionName("Golfers")]
        public static async Task<IActionResult> Golfers(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger Aldarra/Golfers endpoint processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();


            List<Golfer> golfers;
            try
            {
                golfers = JsonConvert.DeserializeObject<List<Golfer>>(requestBody);
            }
            catch (Exception e)
            {
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }

            var responseMessage = JsonConvert.SerializeObject(golfers);
            return new OkObjectResult(responseMessage);
        }
    }
}
