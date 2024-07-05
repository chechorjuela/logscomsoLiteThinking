using LogLiteThinking.Domain.Entities;
using Microsoft.Azure.Cosmos;

namespace LogLiteThinking.Infrastructure.Utils;

public class LogItem
{
  public Guid id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public int Priority { get; set; }
  public DateTime CreatedAt { get; set; }
}
public class CosmoService
{
  private readonly CosmosClient _cosmosClient;
  private readonly string _databaseName;
  private readonly string _containerName;
  private Database _database;
  private Container _container;

  public CosmoService(CosmosClient cosmosClient, string dataBaseName, string containerName)
  {
    
    _container = cosmosClient.GetContainer(dataBaseName, containerName);
  }

  public async Task<List<LogItem>> GetLogItemsAsync()
  {
    var query = new QueryDefinition("SELECT * FROM c");
    var iterator = _container.GetItemQueryIterator<LogItem>(query);

    var logItems = new List<LogItem>();
    while (iterator.HasMoreResults)
    {
      var response = await iterator.ReadNextAsync();
      logItems.AddRange(response.ToList());
    }

    return logItems;
  }
  public async Task UpdateLogItemAsync(string id, LogItem updatedLogItem)
  {
    var partitionKey = new PartitionKey(id);
    var response = await _container.ReplaceItemAsync(updatedLogItem, id, partitionKey);
  }
  public async Task DeleteLogItemAsync(string id)
  {
    var partitionKey = new PartitionKey(id);
    await _container.DeleteItemAsync<LogItem>(id, partitionKey);
  }
  public async Task<List<LogItem>> GetLogItemsByFilterAsync(int? priority = null)
  {
    var sqlQuery = "SELECT * FROM c WHERE";

    if (priority.HasValue)
    {
      sqlQuery += $" c.Priority = {priority}";
    }

    var queryDefinition = new QueryDefinition(sqlQuery);
    var iterator = _container.GetItemQueryIterator<LogItem>(queryDefinition);

    var logItems = new List<LogItem>();
    while (iterator.HasMoreResults)
    {
      var response = await iterator.ReadNextAsync();
      logItems.AddRange(response.ToList());
    }

    return logItems;
  }


  public async Task AddLogAsync(LogItem log)
  {
    await _container.CreateItemAsync(log);
  }
}