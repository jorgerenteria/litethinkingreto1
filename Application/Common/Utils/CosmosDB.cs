using Domain.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Utils
{
    public class CosmosDB(IConfiguration configuration)
    {
        public string ConnectionString { get; set; } = configuration.GetSection("CosmosDB:ConnectionString").Value ?? string.Empty;
        public string Key { get; set; } = configuration.GetSection("CosmosDB:Key").Value ?? string.Empty;
        public string DatabaseName { get; set; } = configuration.GetSection("CosmosDB:DatabaseName").Value ?? string.Empty;
        public string ContainerName { get; set; } = configuration.GetSection("CosmosDB:ContainerName").Value ?? string.Empty;

        
        public async Task InsertDataOperation(FileEntity file)
        {
            var cosmosClient = new CosmosClient(ConnectionString, Key);
            var database = cosmosClient.GetDatabase(DatabaseName);
            var container = await database.CreateContainerIfNotExistsAsync(ContainerName, $"/{DatabaseName}test");


            var document = new FileEntity();

            document.id = file.id;
            document.FileName = file.FileName;
            document.TransactionName = file.TransactionName;

            await container.Container.CreateItemAsync<FileEntity>(document);
        }
    }
}
