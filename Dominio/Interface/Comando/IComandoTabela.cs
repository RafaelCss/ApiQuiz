using Dominio.Respostas;


namespace Dominio.Interface.Comando
{
	public interface IComandoTabela
	{
		Task<ApiResponse> BuscarDadosTabelaAsync();
	}
}
