using FluentValidation;
using Flunt.Validations;

namespace Dominio.Entidades
{
	public class Pergunta : Entidade
	{
		public Pergunta()
		{
		}

		public Pergunta(string titulo, Guid autor, string assunto)
		{
			ValidarTitulo(titulo);
			ValidarAssunto(assunto);
			ValidarAutor(autor);
		}


		public string Titulo { get; private set; }
		public string Assunto { get; private set; }
		public Guid Autor { get; private set; }	
		public virtual Usuario Usuario { get; private set; }

		private Pergunta ValidarTitulo(string titulo)
		{
			Titulo = titulo;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNull(Titulo,"Titulo","Este campo não pode ficar vazio")
			);
			return this;
		}

		private Pergunta ValidarAutor(Guid autor)
		{
			Autor= autor;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNull(Autor,"Autor","Este campo não pode ficar vazio")
			);
			return this;
		}

		private Pergunta ValidarAssunto(string assunto)
		{
			Assunto = assunto;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNullOrWhiteSpace(Assunto,"Assunto", "Este campo não pode ficar vazio")
			);
			return this;
		}
	}
}
