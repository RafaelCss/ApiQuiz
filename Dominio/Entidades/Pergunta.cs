using Dominio.Services.Notificacao;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
	public class Pergunta : Entidade
	{
		public Pergunta()
		{
		}

		public Pergunta(string titulo, string autor, string assunto)
		{
			ValidarTitulo(titulo);
			ValidarAssunto(assunto);
			ValidarAutor(autor);
		}


		public string Titulo { get; private set; }
		public string Autor { get; private set; }
		public string Assunto { get; private set; }

		private void ValidarTitulo(string titulo)
		{
			
			Titulo = titulo;
		}

		private void ValidarAutor(string autor)
		{

			Autor = autor;
		}

		private void ValidarAssunto(string assunto)
		{

			Assunto = assunto;
		}
	}
}
