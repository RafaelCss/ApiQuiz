using Dominio.Entidades;
using Dominio.Entidades.EntidadesMongo;

namespace Dominio.Interface.Autenticacao
{
	public interface IServicoGeradorToken
	{
	   string AddAutenticate(UsuariosMongo user);
	}
}
