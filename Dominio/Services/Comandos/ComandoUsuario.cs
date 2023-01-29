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

		public bool CadastrarUsuario(string nome,string email,string senha)
		{
			var repositorio = _unitOfWork.Repositorio<Usuario>();
			var usuario = new Usuario(nome,email,senha);
			var not = new CustomNotification("","");

			if(!usuario.IsValid)
			{
				return false;
			}
			repositorio.Adicionar(usuario);
			_unitOfWork.Commit();

			return true;
		}
	}
}
