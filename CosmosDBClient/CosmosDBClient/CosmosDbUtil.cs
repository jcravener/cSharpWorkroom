using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBClient
{
    class CosmosDbUtil
    {
        public CosmosConn ParseCosmosConnStr(string connStr)
        {
            CosmosConn returnVal = new CosmosConn();

            foreach (string piece in connStr.Split(";"))
            {
                if (!string.IsNullOrEmpty(piece))
                {
                    if (piece.StartsWith("AccountKey="))
                    {
                        returnVal.AccountKey = piece.Substring("AccountKey=".Length);
                    }
                    if (piece.StartsWith("AccountEndpoint="))
                    {
                        returnVal.AccountEndpoint = piece.Substring("AccountEndpoint=".Length);
                    }
                }
            }

            return returnVal;
        }

        public async Task<List<DatabaseProperties>> ListDatabases(CosmosClient cosmosClient)
        {
            List<DatabaseProperties> databaseProperties = new List<DatabaseProperties>();

            using(FeedIterator<DatabaseProperties> iterator = cosmosClient.GetDatabaseQueryIterator<DatabaseProperties>())
            {
                while (iterator.HasMoreResults)
                {
                    foreach( DatabaseProperties db in await iterator.ReadNextAsync())
                    {
                        databaseProperties.Add(db);
                    }
                }
            }
            return databaseProperties;
        }

        public async Task<List<ContainerProperties>> ListContainers(Database cosmosDb)
        {
            List<ContainerProperties> containerProperties = new List<ContainerProperties>();

            using (FeedIterator<ContainerProperties> iterator = cosmosDb.GetContainerQueryIterator<ContainerProperties>())
            {
                while (iterator.HasMoreResults)
                {
                    foreach(ContainerProperties container in await iterator.ReadNextAsync())
                    {
                        containerProperties.Add(container);
                    }
                }
            }
            return containerProperties;
        }
    }

    class CosmosConn
    {
        public string AccountKey { get; set; }
        public string AccountEndpoint { get; set; }
    }
}
