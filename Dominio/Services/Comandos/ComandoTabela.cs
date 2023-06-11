using Dominio.Entidades;
using Dominio.Interface.Comando;
using Dominio.Interface.MongoRepositorio;
using Dominio.Respostas;

namespace Dominio.Services.Comandos
{
    public class ComandoTabela : Comando, IComandoTabela
	{
		private readonly IMongoRepositorio<TabelaCampeonato> _mongoRepositorio;
		private readonly string collection = typeof(TabelaCampeonato).Name;

		public ComandoTabela(IMongoRepositorio<TabelaCampeonato> mongoRepositorio)
		{
			_mongoRepositorio = mongoRepositorio;
		}

		public async Task<ApiResponse> BuscarDadosTabelaAsync()
		{
			var tabela = await _mongoRepositorio.GetAsync(this.collection);

			var response = new ApiResponse
			(
				 true,
				"Retorno",
				new { tabela }
			);

			return response;
		}
	}
}
