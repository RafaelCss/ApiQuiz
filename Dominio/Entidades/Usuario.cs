using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
	public class Usuario : Entidade<Usuario>
	{
		public Usuario() { }

		public Usuario(string nome, string email)
		{
			ValidarNome(nome);
			ValidarEmail(email);
		}
		public string Nome { get; private set; }
		public string Email { get; set; }
		public string Senha { get; set; }

		public Usuario ValidarNome(string nome)
		{
			if(nome == null)
			RuleFor(x => x.Nome)
				.NotEmpty()
				.NotNull()
				.WithMessage("Este Campo não pode ser vazio");

			Nome = nome;
			return this;
		}

		public Usuario ValidarEmail(string email)
		{
			if(email == null)
				RuleFor(x => x.Email)
					.NotEmpty()
					.NotNull()
					.WithMessage("Este Campo não pode ser vazio");

			Email = email;
			return this;
		}
	}
}
