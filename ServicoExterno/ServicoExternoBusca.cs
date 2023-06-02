using Infra.MongoClient;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Net.Http.Headers;

namespace ServicoExterno;

public class ServicoExternoBusca
{

	private readonly IMongoClient _client;
	private readonly IMongoDatabase _database;
	private readonly string collectionName = "Resultados";
	private readonly IOptions<ConnectMongo> connectMongo;
	private string url;
	private string apiKey;
	public ServicoExternoBusca()
	{

		var ConnectMongo = connectMongo;
		var defaultConnectMongo = new ConnectMongo { ConnectionString = ConnectMongo.Value.ConnectionString,DatabaseName = "ResultadosApiFutebol" };
		var options = Options.Create(defaultConnectMongo);
		_client = new MongoClient(defaultConnectMongo.ConnectionString);
		_database = _client.GetDatabase(defaultConnectMongo.DatabaseName);
	}

	public async Task FazerBusca()
	{

		using(var httpClient = new HttpClient())
		{
			// Configurar o cabeçalho da requisição com a chave de API
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",apiKey);

			// Realizar a chamada para a API
			var response = await httpClient.GetAsync(url);
			if(response.IsSuccessStatusCode)
			{

				var resposta = await response.Content.ReadAsStringAsync();
				var jsonArray = BsonSerializer.Deserialize<BsonArray>(resposta);

				foreach(BsonDocument documento in jsonArray.Cast<BsonDocument>())
				{
					await SalvarDadosDaBuscaNoMongo(documento);
				}
			}
			else
			{
				throw new Exception($"Erro ao fazer a busca na API. Código de status: {response.StatusCode}");
			}
		}
	}

	private async Task SalvarDadosDaBuscaNoMongo(BsonDocument documento)
	{
		var collection = _database.GetCollection<BsonDocument>(collectionName);
		await collection.InsertOneAsync(documento);
	}

}