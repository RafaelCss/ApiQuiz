using Dominio.Respostas;


namespace Dominio.Interface.Comando
{
	public interface IComandoPerguntas
	{
		Task<ApiResponse> CadastrarPergunta(string titulo,string assunto,string autor);
		Task<ApiResponse> BuscarPergunta(string campo,string valor);
		Task<ApiResponse> BuscarPerguntas(string campo,string valor);
		Task<ApiResponse> EditarPergunta(string id,string nome,string email,string senha);
		Task<ApiResponse> DeletarPergunta(string guid);
	}
}
