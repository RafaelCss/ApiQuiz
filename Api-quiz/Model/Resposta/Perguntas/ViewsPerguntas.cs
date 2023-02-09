using ApiQuiz.Model.Resposta.Usuarios;


namespace ApiQuiz.Model.Resposta.Perguntas
{
	public class ViewsPerguntas
	{
		public Guid Id { get; set; }
		public string? Titulo { get; set; }
		public string? Assunto { get; set; }
		public ViewsUsuarios? Autor { get; set; }
	}

}
