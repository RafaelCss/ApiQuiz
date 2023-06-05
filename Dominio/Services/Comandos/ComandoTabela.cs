using Dominio.Entidades.EntidadesMongo;
using Dominio.Interface.Comando;
using Dominio.Interface.MongoRepositorio;
using Dominio.Respostas;

namespace Dominio.Services.Comandos
{
	public class ComandoTabela : Comando, IComandoTabela
	{
		private readonly IMongoRepositorio<TabelaCampenato> _mongoRepositorio;
		private readonly string collection = "Resultados";

		public async Task<ApiResponse> BuscarDadosTabelaAsync()
		{
			throw new NotImplementedException();
		}
	}
}
