


namespace Dominio.Interface.Comando
{
	public interface IComandoUsuario
	{ 
		Task<int> CadastrarUsuario(string nome,string email,string senha);
		Task<int> EditarUsuario(Guid id, string nome,string email,string senha);
		Task<int> DeletarUsuario(Guid guid);
	}
}
