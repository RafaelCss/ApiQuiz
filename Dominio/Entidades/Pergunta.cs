using FluentValidation;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
	public class Pergunta : Entidade<Pergunta>
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
		public Guid Autor { get; private set; }
		public string Assunto { get; private set; }

		private void ValidarTitulo(string titulo)
		{
			RuleFor(x => x.Titulo)
				.NotNull()
				.NotEmpty()
				.WithMessage("Este campo não pode ficar vazio");

			Titulo = titulo;
		}

		private void ValidarAutor(Guid autor)
		{
			RuleFor(x => x.Autor)
				.NotNull()
				.NotEmpty()
				.WithMessage("Este campo não pode ficar vazio");

			Autor = autor;
		}

		private void ValidarAssunto(string assunto)
		{

			RuleFor(x => x.Assunto)
				.NotNull()
				.NotEmpty()
				.WithMessage("Este campo não pode ficar vazio");

			Assunto = assunto;
		}
	}
}
