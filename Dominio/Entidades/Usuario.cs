using Flunt.Validations;

namespace Dominio.Entidades
{
	public class Usuario : Entidade
	{


		public Usuario() { }

		public string Nome { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Senha { get; set; } = string.Empty;

		public Usuario(string nome,string email,string senha)
		{
			ValidarNome(nome);
			ValidarEmail(email);
			ValidarSenha(senha);
		}


		private Usuario ValidarNome(string nome)
		{
			Nome = nome;
			AddNotifications(new Contract<Usuario>()
				.Requires()
				.IsNotNullOrWhiteSpace(Nome,"Nome","Este campo não pode ser vazio")
				);

			return this;
		}

		private Usuario ValidarEmail(string email)
		{
			Email = email;
			AddNotifications(new Contract<Usuario>()
				.Requires()
				.IsNotNullOrWhiteSpace(Email,"Email","Este campo não pode ser vazio")
				.IsEmailOrEmpty(Email,"Email","Este não éum email valido")
				);

			return this;
		}

		private Usuario ValidarSenha(string senha)
		{
			Senha = senha;
			AddNotifications(new Contract<Usuario>()
				.Requires()
				.IsNotNullOrWhiteSpace(Senha,"Senha","Este campo não pode ser vazio")
			);
			return this;
		}
	}
}
