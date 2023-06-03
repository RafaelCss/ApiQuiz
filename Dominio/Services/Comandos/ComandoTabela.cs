using Dominio.Interface.Comando;
using Dominio.Respostas;

namespace Dominio.Services.Comandos
{
	public class ComandoTabela : Comando, IComandoTabela
	{
		public Task<ApiResponse> BuscarDadosTabelaAsync()
		{
			throw new NotImplementedException();
		}
	}
}
