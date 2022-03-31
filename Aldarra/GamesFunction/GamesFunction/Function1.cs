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

namespace GamesFunction
{
    public static class Function1
    {
        [FunctionName("Player")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger Aldarra function endpoint processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Player player;

            try
            {
                player = JsonConvert.DeserializeObject<Player>(requestBody);
            }
            catch(Exception e)
            {
                var errorObjectResult = new ObjectResult(e.Message);
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }

            var response = new Response();
            var playerResponse = response.GetPlayerResponse(player);

            var responseMessage = JsonConvert.SerializeObject(playerResponse);

            //string responseMessage = string.IsNullOrEmpty(name)
            //    ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //    : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}