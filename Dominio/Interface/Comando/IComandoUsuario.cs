using Dominio.Entidades;
using Dominio.Respostas;

namespace Dominio.Interface.Comando
{
	public interface IComandoUsuario
	{
		Task<ApiResponse<Usuario>> CadastrarUsuario(string nome,string email,string senha);
		Task<ApiResponse<Usuario>> BuscarUsuario(string? nome,string email,string senha);
		Task<Usuario> LogarUsuario(string email,string senha);
		Task<int> EditarUsuario(string id,string nome,string email,string senha);
		Task<ApiResponse<Usuario>> DeletarUsuario(string guid);
	}
}
