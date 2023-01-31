using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Comando
{
	public interface IComandoUsuario
	{
		Task<int> CadastrarUsuario(string nome,string email,string senha);
	}
}
