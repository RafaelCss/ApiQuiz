using Dominio.Entidades.EntidadesMongo;
using Dominio.Respostas;

namespace Dominio.Interface.Comando
{
	public interface IComandoUsuario
	{ 
		Task<ApiResponse> CadastrarUsuario(string nome,string email,string senha);
		Task<ApiResponse> BuscarUsuario(string? nome,string email,string senha);
		Task<UsuariosMongo> LogarUsuario(string email,string senha);
		Task<int> EditarUsuario(string id, string nome,string email,string senha);
		Task<ApiResponse> DeletarUsuario(string guid);
	}
}
