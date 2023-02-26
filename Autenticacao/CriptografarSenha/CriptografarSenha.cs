using Dominio.Interface.Autenticacao;
using System.Security.Cryptography;
using System.Text;

namespace Autenticacao.CriptografarSenha
{
	public class CriptografarSenha : ICriptografarSenha
	{
		public string HashSenha(string password)
		{
			using(SHA256 sha256Hash = SHA256.Create())
			{
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

				StringBuilder builder = new StringBuilder();
				for(int i = 0;i < bytes.Length;i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString();
			}
		}

		public bool VerificarSenha(string password,string hashedPassword)
		{
			string hashedInputPassword = HashSenha(password);
			return hashedInputPassword.Equals(hashedPassword);
		}
	}
}
