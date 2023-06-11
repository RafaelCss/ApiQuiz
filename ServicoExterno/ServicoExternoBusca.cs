using Dominio.Entidades;
using Dominio.Interface.MongoRepositorio;
using Dominio.Interface.ServicoExterno;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ServicoExterno;

public class ServicoExternoBusca : IServicoExterno
{
	private string _url { get; set; }
	private string _apiKey { get; set; }
	private IConfiguration _configuration;
	private readonly IMongoRepositorio<TabelaCampeonato> _mongoRepositorio;
	private readonly string collection = typeof(TabelaCampeonato).Name;

	public ServicoExternoBusca(IMongoRepositorio<TabelaCampeonato> mongoRepositorio,IConfiguration configuration)
	{
		_configuration = configuration;
		var apiFutebolConfig = _configuration.GetSection("ApiFutebol");
		_url = apiFutebolConfig["Url"].ToString();
		_apiKey = apiFutebolConfig["Key"].ToString();

		_mongoRepositorio = mongoRepositorio;
	}

	public async Task FazerBusca()
	{

		using(var httpClient = new HttpClient())
		{
			// Configurar o cabeçalho da requisição com a chave de API
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",_apiKey);
			Console.Write(_url);
			// Realizar a chamada para a API
			var response = await httpClient.GetAsync(_url);
			if(response.IsSuccessStatusCode)
			{

				var resposta = await response.Content.ReadAsStringAsync();
				var jsonArray = JsonDocument.Parse(resposta).RootElement;

				foreach(var documento in jsonArray.EnumerateArray())
				{
					Console.WriteLine(documento.ToString());
					var tabelaCampeonato = BsonSerializer.Deserialize<TabelaCampeonato>(documento.GetRawText());
					await SalvarDadosDaBuscaNoMongo(tabelaCampeonato);
				}
			}
			else
			{
				throw new Exception($"Erro ao fazer a busca na API. Código de status: {response.StatusCode}");
			}
		}
		Console.WriteLine("Busca concluida");
	}

	private async Task SalvarDadosDaBuscaNoMongo(TabelaCampeonato documento)
	{
		await _mongoRepositorio.CreateAsync(documento,collection);
		Console.WriteLine("Dasdos Salvos");
	}

}