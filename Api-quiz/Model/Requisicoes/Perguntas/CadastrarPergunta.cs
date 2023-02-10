using System.ComponentModel.DataAnnotations;

namespace ApiQuiz.Model.Requisicoes.Perguntas
{
	public class CadastrarPergunta
	{
		[Required(ErrorMessage ="Este campo é obrigatório")]
		public string Titulo { get; set; }
		[Required(ErrorMessage = "Este campo é obrigatório")]
		public string Assunto { get; set; }
		[Required(ErrorMessage = "Este campo é obrigatório")]
		public string Autor { get; set; }
	}
}
