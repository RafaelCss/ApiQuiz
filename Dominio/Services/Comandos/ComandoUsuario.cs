using Dominio.Entidades;
using Dominio.Entidades.EntidadesMongo;
using Dominio.Interface;
using Dominio.Interface.Autenticacao;
using Dominio.Interface.Comando;
using Dominio.Interface.MongoRepositorio;
using Dominio.Respostas;
using MongoDB.Driver;

namespace Dominio.Services.Comandos
{
	public class ComandoUsuario : Comando , IComandoUsuario
	{
		public ComandoUsuario() { }

		private readonly ICriptografarSenha _criptografarSenha;
		private readonly IMongoRepositorio<UsuariosMongo> _mongoRepositorio;
		private readonly string collection = typeof(UsuariosMongo).Name;

		public ComandoUsuario(ICriptografarSenha criptografarSenha,IMongoRepositorio<UsuariosMongo> mongoRepositorio)
		{
	
			_criptografarSenha= criptografarSenha;
			_mongoRepositorio= mongoRepositorio;
		}

		public async Task<ApiResponse> CadastrarUsuario(string nome,string email,string senha)
		{
			// criptografa senha
			var criptografarSenha = _criptografarSenha.HashSenha(senha);
			// Validamos os dados enviados para cadastro
			var usuario = new Usuario(nome,email,criptografarSenha);
			var user = new UsuariosMongo { Email = email, Nome = nome, Senha = criptografarSenha };

			if(!usuario.IsValid) return new ApiResponse(true,"falhou",new
			{ 
				usuario.Notifications,
			});

			var repositorio = _mongoRepositorio.CreateAsync(user,this.collection);
			// Montamos o modelo de resposta
			var response = new ApiResponse(true,"feito",new{
				repositorio,
			});

			return response;
		}

		public Task<int> EditarUsuario(Guid id,string nome,string email,string senha)
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

		public async Task<ApiResponse> BuscarUsuario(string nome,string email,string id)
		{
			var repositorio = _mongoRepositorio.GetAsyncId(id,this.collection);
			var response = new ApiResponse(true,"feito",new
			{
				repositorio,
			});
			return response;
		}
		#region Logar Usuario
		public async Task<UsuariosMongo> LogarUsuario(string email,string senha)
		{
			var criptografarSenha = _criptografarSenha.HashSenha(senha);
			var filter = Builders<UsuariosMongo>.Filter.And(
						 Builders<UsuariosMongo>.Filter.Eq("Email",email),
						 Builders<UsuariosMongo>.Filter.Eq("Senha",criptografarSenha));

			var user = _mongoRepositorio.GetAsyncFiltro(this.collection,filter);
		
			return user.Result;
		}
		#endregion
	}
}