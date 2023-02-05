
using Dominio.Entidades;
using Dominio.Interface.Comando.ComandoBase;
using Flunt.Notifications;

namespace Dominio.Interface.Comando
{
	public interface IComandoUsuario : IComando
	{ 
		Task<int> CadastrarUsuario(string nome,string email,string senha);
		Task<int> EditarUsuario(Guid id, string nome,string email,string senha);
		Task<int> DeletarUsuario(Guid guid);
	}
}
