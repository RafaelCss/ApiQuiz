using Dominio.Entidades;
using Dominio.Interface.Autenticacao;
using Dominio.Interface.Comando;
using Dominio.Interface.MongoRepositorio;
using Dominio.Respostas;
using MongoDB.Driver;

namespace Dominio.Services.Comandos
{
	public class ComandoUsuario : Comando, IComandoUsuario
	{

		private readonly ICriptografarSenha _criptografarSenha;
		private readonly IMongoRepositorio<Usuario> _mongoRepositorio;
		private readonly string collection = typeof(Usuario).Name;

		public ComandoUsuario(ICriptografarSenha criptografarSenha,IMongoRepositorio<Usuario> mongoRepositorio)
		{

			_criptografarSenha = criptografarSenha;
			_mongoRepositorio = mongoRepositorio;
		}
		#region Cadastrar Usuario
		public async Task<ApiResponse> CadastrarUsuario(string nome,string email,string senha)
		{
			// criptografa senha
			var criptografarSenha = _criptografarSenha.HashSenha(senha);
			// Validamos os dados enviados para cadastro
			var usuario = new Usuario(nome,email,criptografarSenha);
			var user = new Usuario { Email = email,Nome = nome,Senha = criptografarSenha };

			if(!usuario.IsValid) return new ApiResponse(true,"falhou",new
			{
				usuario.Notifications,
			});

			var repositorio = _mongoRepositorio.CreateAsync(user,this.collection);
			// Montamos o modelo de resposta
			var response = new ApiResponse(true,"feito",new
			{
				repositorio,
			});

			return response;
		}
		#endregion

		public Task<int> EditarUsuario(string id,string nome,string email,string senha)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse> DeletarUsuario(string guid)
		{
			var repositorio = _mongoRepositorio.DeleteAsync(guid,this.collection);

			var response = new ApiResponse(true,"feito",new
			{
				repositorio,
			});

			return response;
		}

		#region Buscar Usuario
		public async Task<ApiResponse> BuscarUsuario(string nome,string email,string id)
		{
			var repositorio = _mongoRepositorio.GetAsyncId(id,this.collection);
			var response = new ApiResponse(true,"feito",new
			{
				repositorio,
			});
			return response;
		}
		#endregion

		#region Logar Usuario
		public async Task<Usuario> LogarUsuario(string email,string senha)
		{
			var criptografarSenha = _criptografarSenha.HashSenha(senha);
			var filter = Builders<Usuario>.Filter.And(
						 Builders<Usuario>.Filter.Eq("Email",email),
						 Builders<Usuario>.Filter.Eq("Senha",criptografarSenha));

			var user = _mongoRepositorio.GetAsyncFiltro(this.collection,filter);

			return user.Result;
		}
		#endregion

	}
}