﻿using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;

// This code is based on the CosmosDB tutorial located here: https://docs.microsoft.com/en-us/azure/cosmos-db/sql-api-get-started

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
                Console.Error.WriteLine($"Eror: {ex}");
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
            Console.WriteLine();
            await this.AddItemToContainerAsync(CreateAndersenItem());
            await this.AddItemToContainerAsync(CreateWakefieldItem());
            await this.AddItemToContainerAsync(CreateSmithItem());
            Console.WriteLine();
            await this.QueryItemsAsync("Andersen");
            Console.WriteLine();
            await this.QueryItemsAsync("Wakefield");
            Console.WriteLine();
            await this.ReplaceFamilyItemAsync("Andersen.1", "Andersen", "Roslyn");
            Console.WriteLine();
            await this.DeleteFamilyItemAsync("Smith.1", "Smith");
            //Console.WriteLine();
            //await this.DeleteContainerAsync();
            //Console.WriteLine();
            //await this.DelteDatabaseAsync();
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

        private async Task AddItemToContainerAsync(Family Item)
        {
            try
            {
                ItemResponse<Family> ItemResponse = await this.container.ReadItemAsync<Family>(Item.Id, new PartitionKey(Item.LastName));
                Console.WriteLine($"Item with id {Item.Id} already exists. The opperation consumed {ItemResponse.RequestCharge} RUs.");
            }
            catch
            {
                ItemResponse<Family> ItemResponse = await this.container.CreateItemAsync<Family>(Item, new PartitionKey(Item.LastName));
                Console.WriteLine($"Created new item in database with id {Item.Id}. The opperation consumed {ItemResponse.RequestCharge} RUs.");
            }
        }

        private async Task QueryItemsAsync(string lastName)
        {
            var sqlQueryText = $"SELECT * from c WHERE c.LastName = '{lastName}'";

            Console.WriteLine($"Running query: {sqlQueryText}\n");

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<Family> queryResultSetIterator = this.container.GetItemQueryIterator<Family>(queryDefinition);

            List<Family> families = new List<Family>();

            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<Family> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (Family family in currentResultSet)
                {
                    families.Add(family);
                    Console.WriteLine(family);
                }
            }
        }

        private async Task ReplaceFamilyItemAsync(string itemId, string lastName, string newCity)
        {
            ItemResponse<Family> familyItemResponse = await this.container.ReadItemAsync<Family>(itemId, new PartitionKey(lastName));
            var itemBody = familyItemResponse.Resource;

            string oldCity = itemBody.Address.City;
            itemBody.Address.City = newCity;

            familyItemResponse = await this.container.ReplaceItemAsync<Family>(itemBody, itemBody.Id, new PartitionKey(itemBody.LastName));
            Console.WriteLine($"Updated family {lastName}'s city from {oldCity} to {itemBody.Address.City}.");
        }

        private async Task DeleteFamilyItemAsync(string itemId, string lastName)
        {
            ItemResponse<Family> itemResponse = await this.container.DeleteItemAsync<Family>(itemId, new PartitionKey(lastName));
            Console.WriteLine($"Deleted family with ID {itemId}");
        }

        private static Family CreateAndersenItem()
        {
            Family Item = new Family()
            {
                Id = "Andersen.1",
                LastName = "Andersen",
                Parents = new Parent[]
                {
                    new Parent { FamilyName = "Thopmas"},
                    new Parent { FirstName = "Mary Kay"}
                },
                Children = new Child[]
                {
                    new Child
                    {
                        FirstName = "Henriette",
                        Gender = "female",
                        Grade = 5,
                        Pets = new Pet[]
                        {
                            new Pet { GivinName = "Fuffy"}
                        }
                    }
                },
                Address = new Address { State = "WA", County = "King", City = "Redmond" },
                IsRegistered = false
            };

            return Item;
        }

        private async Task DeleteContainerAsync()
        {
            ContainerResponse containerResponse = await this.container.DeleteContainerAsync();
            Console.WriteLine($"Deleted container: {containerId}, {containerResponse.StatusCode}");
        }

        private async Task DelteDatabaseAsync()
        {
            DatabaseResponse databaseResponse = await this.database.DeleteAsync();
            Console.WriteLine($"Deleted database: {databaseId}, {databaseResponse.StatusCode}");
        }

        private static Family CreateWakefieldItem()
        {
            Family Item = new Family()
            {
                Id = "Wakefield.1",
                LastName = "Wakefield",
                Parents = new Parent[]
                {
                    new Parent { FirstName = "Beth", FamilyName = "Wakefield"},
                    new Parent { FirstName = "Tim"}
                },
                Children = new Child[]
                {
                    new Child
                    {
                        FirstName = "Mary",
                        Gender = "female",
                        Grade = 4,
                        Pets = new Pet[]
                        {
                            new Pet { GivinName = "Spot"}
                        }
                    }
                },
                Address = new Address { State = "WA", County = "King", City = "Bellevue" },
                IsRegistered = true
            };

            return Item;
        }

        private static Family CreateSmithItem()
        {
            Family Item = new Family()
            {
                Id = "Smith.1",
                LastName = "Smith",
                Parents = new Parent[]
                {
                    new Parent { FirstName = "Betty", FamilyName = "Smith"},
                    new Parent { FirstName = "Larry"}
                },
                Children = new Child[]
                {
                    new Child
                    {
                        FirstName = "Rose",
                        Gender = "female",
                        Grade = 5,
                        Pets = new Pet[]
                        {
                            new Pet { GivinName = "Sandle"}
                        }
                    }
                },
                Address = new Address { State = "WA", County = "Chellan", City = "Chellan" },
                IsRegistered = true
            };

            return Item;
        }
    }
}

