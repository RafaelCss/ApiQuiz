using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Interface.Autenticacao;
using Dominio.Interface.Comando;
using Dominio.Respostas;


namespace Dominio.Services.Comandos
{
	public class ComandoUsuario : Comando , IComandoUsuario
	{
		public ComandoUsuario() { }

		private readonly IUnitOfWork _unitOfWork;
		private readonly ICriptografarSenha _criptografarSenha;

		public ComandoUsuario(IUnitOfWork unitOfWork,ICriptografarSenha criptografarSenha)
		{
			_unitOfWork = unitOfWork;
			_criptografarSenha= criptografarSenha;
		}

		public async Task<ApiResponse> CadastrarUsuario(string nome,string email,string senha)
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();
			// criptografa senha
			var criptografarSenha = _criptografarSenha.HashSenha(senha);
			// Validamos os dados enviados para cadastro
			var usuario = new Usuario(nome,email,criptografarSenha);
			// Montamos o modelo de resposta
			var response = new ApiResponse(true,"feito",usuario);

			if(!usuario.IsValid) return response;
			
			var teste = repositorio.Adicionar(usuario);
			var resultado = await _unitOfWork.Commit();

			return response;
		}

		public Task<int> EditarUsuario(Guid id,string nome,string email,string senha)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeletarUsuario(Guid guid)
		{
			throw new NotImplementedException();
		}

		public Task<Usuario> BuscarUsuario(string nome,string email, string id )
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();
			var usuario = repositorio.Get(x => x.Email == email ||  x.Nome == nome || x.Id == Guid.Parse(id));
			return usuario;
		}

		public Task<Usuario> LogarUsuario(string email,string senha)
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();

			var criptografarSenha = _criptografarSenha.HashSenha(senha);

			var usuario = repositorio.Get(x => x.Email == email && x.Senha == criptografarSenha);
			return usuario;
		}
	}
}