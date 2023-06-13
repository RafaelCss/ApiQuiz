using Dominio.Entidades;
using Dominio.Interface.Comando;
using Dominio.Interface.MongoRepositorio;
using Dominio.Respostas;
using MongoDB.Driver;

namespace Dominio.Services.Comandos;

public class ComandoPerquntas : Comando, IComandoPerguntas
{
	private readonly IMongoRepositorio<Pergunta> _mongoRepositorio;
	private readonly string collection = typeof(Pergunta).Name;

	public ComandoPerquntas(IMongoRepositorio<Pergunta> mongoRepositorio)
	{
		_mongoRepositorio = mongoRepositorio;
	}

	public async Task<ApiResponse<Pergunta>> BuscarPergunta(string campo,string valor)
	{
		//var filter =Builders<PerguntasMongo>.Filter.And(
		//				Builders<PerguntasMongo>.Filter.Eq(campo,valor),
		//				Builders<PerguntasMongo>.Filter.Eq(campo,valor));

		var filter = Builders<Pergunta>.Filter.Eq(campo,valor);
		var pergunta = await _mongoRepositorio.GetAsyncFiltro(this.collection,filter);

		var response = new ApiResponse<Pergunta>
		(
			 true,
			"Retorno",
			new { pergunta }

		);

		return response;
	}

	public async Task<ApiResponse<Pergunta>> BuscarPerguntas(string campo,string valor)
	{
		var perguntas = await _mongoRepositorio.GetAsync(this.collection);

		var response = new ApiResponse<Pergunta>
		(
			 true,
			"Retorno",
			new { perguntas }
		);

		return response;
	}

	public async Task<ApiResponse<Pergunta>> CadastrarPergunta(string titulo,string assunto,string autor)
	{
		var pergunta = new Pergunta(titulo,autor,assunto);

		if(!pergunta.IsValid)
		{
			return new ApiResponse<Pergunta>
			(
				false,
				"Retorno",
				new { pergunta.Notifications }
			);
		}
		var repositorio = _mongoRepositorio.CreateAsync(pergunta,this.collection);
		var response = new ApiResponse<Pergunta>
			(
				true,
				"Retorno",
				new { repositorio }
			);
		return response;
	}

	public async Task<ApiResponse<Pergunta>> DeletarPergunta(string id)
	{
		var repositorio = await _mongoRepositorio.DeleteAsync(id,this.collection);

		var response = new ApiResponse<Pergunta>(true,"feito",new
		{
			repositorio,
		});

		return response;
	}

	public async Task<ApiResponse<Pergunta>> EditarPergunta(string id,string titulo,string assunto)
	{
		Pergunta perguntaEditada = new()
		{
			Titulo = titulo,
			Assunto = assunto
		};
		var update = Builders<Pergunta>.Update
			.Set(x => x.Titulo,titulo)
			.Set(x => x.Assunto,assunto);
		var repositorio = await _mongoRepositorio.UpdateAsync(id,update,this.collection);
		var response = new ApiResponse<Pergunta>(true,"feito",new
		{
			repositorio,
		});
		return response;
	}
}

