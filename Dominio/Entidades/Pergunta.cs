using Flunt.Validations;

namespace Dominio.Entidades
{
	public class Pergunta : Entidade
	{
		public string Titulo { get; set; }

		public string Assunto { get; set; }

		public string? Autor_id { get; set; }
		public virtual Usuario Usuario { get; private set; }
		public Pergunta()
		{
		}

		public Pergunta(string titulo,string? autor,string assunto)
		{
			ValidarTitulo(titulo);
			ValidarAssunto(assunto);
			ValidarAutor(autor);
		}

		private Pergunta ValidarTitulo(string titulo)
		{
			Titulo = titulo;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNull(Titulo,"Titulo","Este campo não pode ficar vazio")
			);
			return this;
		}

		private Pergunta ValidarAutor(string? autor)
		{
			Autor_id = autor;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNull(Autor_id,"Autor","Este campo não pode ficar vazio")
			);
			return this;
		}

		private Pergunta ValidarAssunto(string assunto)
		{
			Assunto = assunto;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNullOrWhiteSpace(Assunto,"Assunto","Este campo não pode ficar vazio")
			);
			return this;
		}
	}
}
