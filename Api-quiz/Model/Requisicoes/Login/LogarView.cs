using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiQuiz.Model.Requisicoes.Login
{
	public class LogarView
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[PasswordPropertyText]
		public string Senha { get; set; }
	}
}
