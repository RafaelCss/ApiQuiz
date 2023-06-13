using Dominio.Entidades;
using Dominio.Respostas;

namespace Dominio.Interface.Comando
{
	public interface IComandoPerguntas
	{
		Task<ApiResponse<Pergunta>> CadastrarPergunta(string titulo,string assunto,string autor);
		Task<ApiResponse<Pergunta>> BuscarPergunta(string campo,string valor);
		Task<ApiResponse<Pergunta>> BuscarPerguntas(string campo,string valor);
		Task<ApiResponse<Pergunta>> EditarPergunta(string id,string titulo,string assunto);
		Task<ApiResponse<Pergunta>> DeletarPergunta(string guid);
	}
}
