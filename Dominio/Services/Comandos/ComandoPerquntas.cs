using Dominio.Entidades;
using Dominio.Entidades.PerguntasMongo;
using Dominio.Interface.Comando;
using Dominio.Interface.MongoRepositorio;
using Dominio.Respostas;
using MongoDB.Driver;

namespace Dominio.Services.Comandos;

public class ComandoPerquntas : Comando, IComandoPerguntas
{
	private readonly IMongoRepositorio<PerguntasMongo> _mongoRepositorio;
	private readonly string collection = typeof(PerguntasMongo).Name;

	public ComandoPerquntas(IMongoRepositorio<PerguntasMongo> mongoRepositorio)
	{
		_mongoRepositorio = mongoRepositorio;
	}

	public async Task<ApiResponse> BuscarPergunta(string campo,string valor)
	{
		//var filter =Builders<PerguntasMongo>.Filter.And(
		//				Builders<PerguntasMongo>.Filter.Eq(campo,valor),
		//				Builders<PerguntasMongo>.Filter.Eq(campo,valor));

		var filter = Builders<PerguntasMongo>.Filter.Eq(campo,valor);
		var pergunta = await _mongoRepositorio.GetAsyncFiltro(this.collection,filter);

		var response = new ApiResponse
		(
			 true,
			"Retorno",
			new { pergunta }

		);

		return response;
	}

	public async Task<ApiResponse> BuscarPerguntas(string campo,string valor)
	{
		var perguntas = await _mongoRepositorio.GetAsync(this.collection);

		var response = new ApiResponse
		(
			 true,
			"Retorno",
			new { perguntas }
		);

		return response;
	}

	public async Task<ApiResponse> CadastrarPergunta(string titulo,string assunto,string autor)
	{
		var validarPergunta = new Pergunta(titulo,autor,assunto);

		if(!validarPergunta.IsValid)
		{
			return new ApiResponse
			(
				false,
				"Retorno",
				new { validarPergunta.Notifications }
			);
		}

		var pergunta = new PerguntasMongo { Assunto = assunto,Autor_id = autor,Titulo = titulo };
		var repositorio = _mongoRepositorio.CreateAsync(pergunta,this.collection);
		var response = new ApiResponse
			(
				true,
				"Retorno",
				new { repositorio }
			);
		return response;
	}

	public async Task<ApiResponse> DeletarPergunta(string id)
	{
		var repositorio = await _mongoRepositorio.DeleteAsync(id,this.collection);

		var response = new ApiResponse(true,"feito",new
		{
			repositorio,
		});

		return response;
	}

	public async Task<ApiResponse> EditarPergunta(string id,string titulo,string assunto)
	{
		PerguntasMongo perguntaEditada = new()
		{
			Titulo = titulo,
			Assunto = assunto
		};
		var update = Builders<PerguntasMongo>.Update
			.Set(x => x.Titulo,titulo)
			.Set(x => x.Assunto,assunto);
		var repositorio = await _mongoRepositorio.UpdateAsync(id,update,this.collection);
		var response = new ApiResponse(true,"feito",new
		{
			repositorio,
		});
		return response;
	}
}

