using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Interface.Comando;
using Dominio.Services.Notificacoes;
using Flunt.Notifications;

namespace Dominio.Services.Comandos
{
	public class ComandoUsuario : Comando
	{
		private readonly IUnitOfWork _unitOfWork;

		public ComandoUsuario(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<int> CadastrarUsuario(string nome,string email,string senha)
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();
			var usuario = new Usuario(nome,email,senha);

			if(!usuario.IsValid)
			{
				return 0;
			}
			repositorio.Adicionar(usuario);
			var resultado = await _unitOfWork.Commit();

			return resultado;
		}

		public Task<int> EditarUsuario(Guid id,string nome,string email,string senha)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeletarUsuario(Guid guid)
		{
			throw new NotImplementedException();
		}

	}
}