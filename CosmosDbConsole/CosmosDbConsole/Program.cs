using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;

namespace CosmosDbConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string usgMsg = $"usage: {System.AppDomain.CurrentDomain.FriendlyName} <EndpointUri> <PrimaryKey>";
            if (args.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Error.WriteLine(usgMsg);
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            string EndpointUri = args[0];
            string PrimaryKey = args[1];

            Console.WriteLine($"EndpointUri: {EndpointUri} PrimaryKey: {PrimaryKey}");

            try
            {
                Console.WriteLine("Beginning operations...\n");
                Program p = new Program();
                await p.GetStartedDemoAsync(EndpointUri, PrimaryKey);
            }
            catch (CosmosException de)
            {
                Exception baseException = de.GetBaseException();
                Console.Error.WriteLine($"{de.StatusCode} error occured: {de}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Eror: {ex}");
            }
            finally
            {
                Console.WriteLine("\nEnd of demo.\n");
            }

        }

        private CosmosClient cosmosClient;
        private Database database;
        private Container container;

        private string databaseId = "FamilyDB";
        private string containerId = "FamilyContainer";
    
        public async Task GetStartedDemoAsync(string ep, string pk)
        {
            this.cosmosClient = new CosmosClient(ep, pk);
            await this.CreateDatabaseAsync();
            await this.CreateContainerAsync();
        }

        private async Task CreateDatabaseAsync()
        {
            this.database = await this.cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
            Console.WriteLine($"Created database: {this.database.Id}");
        }

        private async Task CreateContainerAsync()
        {
            this.container = await this.database.CreateContainerIfNotExistsAsync(containerId, "/LastName");
            Console.WriteLine($"Created container: {this.container.Id}");
        }
    }
}
