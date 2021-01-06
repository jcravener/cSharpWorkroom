using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

            using (FeedIterator<DatabaseProperties> iterator = cosmosClient.GetDatabaseQueryIterator<DatabaseProperties>())
            {
                while (iterator.HasMoreResults)
                {
                    foreach (DatabaseProperties db in await iterator.ReadNextAsync())
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
                    foreach (ContainerProperties container in await iterator.ReadNextAsync())
                    {
                        containerProperties.Add(container);
                    }
                }
            }
            return containerProperties;
        }

        public async Task<List<DocumentId>> ListDocumentIds(Database cosmosDB, String containerId)
        {
            List<DocumentId> documentIds = new List<DocumentId>();
            Container container = cosmosDB.GetContainer(containerId);
            
            var sqlQueryText = $"SELECT c.id, c._etag, c._ts FROM c";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            
            using (FeedIterator<DocumentId> queryResultSetIterator = container.GetItemQueryIterator<DocumentId>(queryDefinition))
            {
                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<DocumentId> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach(DocumentId documentId in currentResultSet)
                    {
                        documentIds.Add(documentId);
                    }
                }
            }

            return documentIds;
        }

        public async Task<dynamic> GetDocumentByQuery(Database cosmosDB, String containerId, String documentId)
        {
            dynamic document = null;
            Container container = cosmosDB.GetContainer(containerId);

            var sqlQueryText = $"SELECT * FROM c WHERE c.id = \"{documentId}\"";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

            using (FeedIterator<dynamic> queryResultSetIterator = container.GetItemQueryIterator<dynamic>(queryDefinition))
            {
                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach(dynamic doc in currentResultSet)
                    {
                        //document = doc;
                        return doc;
                    }
                }
            }
            return document;
        }

        public async Task<dynamic> GetDocument(Database cosmosDB, String containerId, String documentId, String partitionKey)
        {
            Container container = cosmosDB.GetContainer(containerId);

            dynamic doc = await container.ReadItemAsync<dynamic>(documentId, new PartitionKey(partitionKey));
            return doc;
        }
    }

    class CosmosConn
    {
        public string AccountKey { get; set; }
        public string AccountEndpoint { get; set; }
    }

    class DocumentId
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "_etag")]
        public string Etag { get; set; }
        [JsonProperty(PropertyName = "_ts")]
        public double Ts { get; set; }
    }

}
