using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;

namespace CosmosDBClient
{
    class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            string usgMsg = $"usage: {System.AppDomain.CurrentDomain.FriendlyName} <CosmosConnStr> [DatabaseName] [ContainerName] [Id] [PartitionKey]";
            if (args.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Error.WriteLine(usgMsg);
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
            string connStr = args[0];

            CosmosClient cosmosClient = null;
            Database cosmosDatabase;
            CosmosDbUtil cosmosDbUtil = new CosmosDbUtil();
            CosmosConn cosmosConn;            
            
            try
            {
                cosmosConn = cosmosDbUtil.ParseCosmosConnStr(connStr);
                cosmosClient = new CosmosClient(cosmosConn.AccountEndpoint, cosmosConn.AccountKey);
                //cosmosDatabase = cosmosClient.GetDatabase(databaseName);
            }
            catch (CosmosException ce)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine($"Had problems creating CosmosDB client.");
                Console.Error.WriteLine(ce.ToString());
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine(ex.Message);
                Console.ResetColor();
            }

            List<DatabaseProperties> databaseProperties;
            List<ContainerProperties> containerProperties;
            if(args.Length == 1) // list databases
            {
                try
                {
                    databaseProperties = new List<DatabaseProperties>();

                    databaseProperties = await cosmosDbUtil.ListDatabases(cosmosClient);
                    Console.WriteLine("DatabaseId");
                    foreach(DatabaseProperties dbp in databaseProperties)
                    {
                        Console.WriteLine(dbp.Id);
                    }
                }
                catch (CosmosException ce)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($"Had problems listing CosmosDB databases.");
                    Console.Error.WriteLine(ce.ToString());
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            else if(args.Length == 2) // list containers
            {
                try
                {
                    containerProperties = new List<ContainerProperties>();

                    cosmosDatabase = cosmosClient.GetDatabase(args[1]);
                    containerProperties = await cosmosDbUtil.ListContainers(cosmosDatabase);
                    Console.WriteLine("ContainerId,PartitionKeyPath");
                    foreach(ContainerProperties cp in containerProperties)
                    {
                        Console.WriteLine($"{cp.Id},{cp.PartitionKeyPath}");
                    }
                }
                catch (CosmosException ce)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($"Had problems listing CosmosDB containers in {args[1]}.");
                    Console.Error.WriteLine(ce.ToString());
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(ex.Message);
                    Console.ResetColor();
                }

            }
        }
    }
}
