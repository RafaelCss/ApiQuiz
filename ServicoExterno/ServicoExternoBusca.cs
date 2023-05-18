using Infra.MongoClient;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace ServicoExterno;

public class ServicoExternoBusca
{
	private readonly IMongoClient _client;
	private readonly IMongoDatabase _database;

	public ServicoExternoBusca(IOptions<ConnectMongo> connectMongo)
	{
		_client = new MongoClient(connectMongo.Value.ConnectionString);

		_database = _client.GetDatabase(connectMongo.Value.DatabaseName);
	}

	public ServicoExternoBusca()
	{
	}

	public async Task<string> FazerBusca(string url,string apiKey)
	{
		using(var httpClient = new HttpClient())
		{
			// Configurar o cabeçalho da requisição com a chave de API
			httpClient.DefaultRequestHeaders.Add("X-API-Key",apiKey);

			// Realizar a chamada para a API
			var response = await httpClient.GetAsync(url);
			if(response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsStringAsync();
			}
			else
			{
				throw new Exception($"Erro ao fazer a busca na API. Código de status: {response.StatusCode}");
			}
		}
	}
	//static void CriarCamposDinamicamente(IMongoCollection<BsonDocument> collection,BsonDocument documento)
	//{
	//	// Converter o BsonDocument para um objeto JSON
	//	var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
	//	var jsonString = documento.ToJson(jsonWriterSettings);

	//	// Ler o JSON como um objeto BsonDocument para acessar os campos dinamicamente
	//	using(var jsonReader = new JsonReader(jsonString))
	//	{
	//		var context = BsonDeserializationContext.CreateRoot(jsonReader);
	//		var bsonDocumentSerializer = new BsonDocumentSerializer();
	//		var bsonDocument = bsonDocumentSerializer.Deserialize(context);

	//		// Iterar sobre os campos do documento e criar no MongoDB
	//		foreach(var campo in bsonDocument.Elements)
	//		{
	//			CriarCampo(collection,campo.Name);
	//		}
	//	}
	//}

	//static void CriarCampo(IMongoCollection<BsonDocument> collection,string nomeCampo)
	//{
	//	// Verificar se o campo já existe na coleção
	//	var campoExistente = collection.Find(Builders<BsonDocument>.Filter.Empty)
	//		.Project(Builders<BsonDocument>.Projection.Include(nomeCampo))
	//		.FirstOrDefault();

	//	if(campoExistente == null)
	//	{
	//		// Criar o campo na coleção
	//		var updateDefinition = Builders<BsonDocument>.Update.Set(nomeCampo,BsonNull.Value);
	//		collection.UpdateMany(Builders<BsonDocument>.Filter.Empty,updateDefinition);
	//	}
	//}
}