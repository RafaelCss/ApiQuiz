using Dominio.Entidades;


namespace Dominio.Interface.Autenticacao
{
	public interface IServicoGeradorToken
	{
	   string AddAutenticate(Usuario user);
	}
}
