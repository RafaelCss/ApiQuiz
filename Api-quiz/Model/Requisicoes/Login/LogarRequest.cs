using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiQuiz.Model.Requisicoes.Login
{
	public class LogarRequest
	{
		[EmailAddress]
		public required string Email { get; set; }

		[PasswordPropertyText]
		public required string Senha { get; set; }
	}
}
