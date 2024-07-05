using System.Net;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace LogLiteThinking.Infrastructure.Config.CosmoDb;

public class LogsCosmoDb
{
  public SettigsDbCosmo _settings;

  public LogsCosmoDb(IConfiguration configuration)
  {
    _settings.Uri = "";
    _settings.Key = "";
    _settings.DatabaseName = "";
    _settings.Container = "";
  }

  public async Task AddLog()
  {
    var cosmosClient = new CosmosClient(_settings.Uri, _settings.Key);
    var dataBase = cosmosClient.GetDatabase(_settings.DatabaseName);
    var container = dataBase.GetContainer(_settings.Container);

    var document = new
    {
      id = Guid.NewGuid(),
      name = "Sergio",
      age = 29
    };

    var response = await container.CreateItemAsync(document);
    if (response.StatusCode == HttpStatusCode.Created)
    {
      Console.WriteLine("Creado");
    }

  }
}