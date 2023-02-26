using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Autenticacao
{
	public interface ICriptografarSenha
	{
		string HashSenha(string password);
		bool VerificarSenha(string password,string hashedPassword);
	}
}
