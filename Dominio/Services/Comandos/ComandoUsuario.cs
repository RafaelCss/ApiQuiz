using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Interface.Comando;
using Dominio.Respostas;


namespace Dominio.Services.Comandos
{
	public class ComandoUsuario : Comando , IComandoUsuario
	{
		private readonly IUnitOfWork _unitOfWork;

		public ComandoUsuario() { }
		public ComandoUsuario(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse> CadastrarUsuario(string nome,string email,string senha)
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();
			var usuario = new Usuario(nome,email,senha);
			var response = new ApiResponse(true,"feito",usuario);

			if(!usuario.IsValid) return response;
			
			 repositorio.Adicionar(usuario);
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

		public Task<Usuario> BuscarUsuario(string nome,string email,string senha)
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();
			var usuario = repositorio.Get(x => x.Email == email);
			return usuario;
		}
	}
}