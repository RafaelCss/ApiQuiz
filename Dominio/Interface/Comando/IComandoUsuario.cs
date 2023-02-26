using Dominio.Entidades;
using Dominio.Respostas;

namespace Dominio.Interface.Comando
{
	public interface IComandoUsuario
	{ 
		Task<ApiResponse> CadastrarUsuario(string nome,string email,string senha);
		Task<Usuario> BuscarUsuario(string? nome,string email,string senha);
		Task<int> EditarUsuario(Guid id, string nome,string email,string senha);
		Task<int> DeletarUsuario(Guid guid);
	}
}
