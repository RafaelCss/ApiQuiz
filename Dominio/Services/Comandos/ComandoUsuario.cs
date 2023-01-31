using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Interface.Comando;
using Dominio.Services.Notificacoes;

namespace Dominio.Services.Comandos
{ 
    public class ComandoUsuario :  IComandoUsuario
	{
        private readonly IUnitOfWork _unitOfWork;

        public ComandoUsuario()
        {

        }
		public ComandoUsuario(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork; 
        }

		public async Task<int> CadastrarUsuario(string nome,string email,string senha)
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();
			var usuario = new Usuario(nome,email,senha);
			var not = new CustomNotification("","");

			if(!usuario.IsValid)
			{
				return 0;
			}
				 repositorio.Adicionar(usuario);
				var reulstado =  await _unitOfWork.Commit();

			return reulstado;
		}
	}
}
