using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
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
            List<DocumentId> documentIds;
            //string json = null;
            if (args.Length == 1) // list databases
            {
                try
                {
                    databaseProperties = new List<DatabaseProperties>();

                    databaseProperties = await cosmosDbUtil.ListDatabases(cosmosClient);
                    foreach (DatabaseProperties dbp in databaseProperties)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(dbp));
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
            else if (args.Length == 2) // list containers
            {
                try
                {
                    containerProperties = new List<ContainerProperties>();

                    cosmosDatabase = cosmosClient.GetDatabase(args[1]);
                    containerProperties = await cosmosDbUtil.ListContainers(cosmosDatabase);
                    foreach (ContainerProperties cp in containerProperties)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(cp));
                    }
                }
                catch (CosmosException ce)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($"Had problems listing CosmosDB containers in {args[2]}.");
                    Console.Error.WriteLine(ce.Message);
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            else if (args.Length == 3) // List doc ids from container
            {
                try
                {
                    documentIds = new List<DocumentId>();
                    cosmosDatabase = cosmosClient.GetDatabase(args[1]);

                    documentIds = await cosmosDbUtil.ListDocumentIds(cosmosDatabase, args[2]);
                    foreach (DocumentId documentId in documentIds)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(documentId));
                    }
                }
                catch (CosmosException ce)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($"Had problems listing Ids in container {args[1]}.");
                    Console.Error.WriteLine(ce.Message);
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            else if (args.Length == 4) // Query for specific doc using Id only
            {
                try
                {
                    dynamic document = null;
                    cosmosDatabase = cosmosClient.GetDatabase(args[1]);

                    document = await cosmosDbUtil.GetDocumentByQuery(cosmosDatabase, args[2], args[3]);
                    Console.WriteLine(JsonConvert.SerializeObject(document));
                }
                catch (CosmosException ce)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($"Had problems getting doc Id {args[3]}.");
                    Console.Error.WriteLine(ce.Message);
                    Console.ResetColor();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            else if (args.Length == 5) // Get doc by ID and Part Key
            {
                try
                {
                    dynamic document = null;
                    cosmosDatabase = cosmosClient.GetDatabase(args[1]);

                    document = await cosmosDbUtil.GetDocument(cosmosDatabase, args[2], args[3], args[4]);
                    Console.WriteLine(JsonConvert.SerializeObject(document));
                }
                catch (CosmosException ce)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine($"Had problems getting doc Id {args[3]} with partition key {args[4]}.");
                    Console.Error.WriteLine(ce.Message);
                    Console.ResetColor();
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
