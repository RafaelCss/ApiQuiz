using ApiQuiz.Model.Requisicoes.Usuarios;
using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Interface.Comando;
using Dominio.Services.Comandos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IComandoUsuario _comando;
		private readonly IUnitOfWork _unitOfWork;
		public UsuarioController(IComandoUsuario comando, IUnitOfWork unitOfWork)
		{
			_comando= comando;
			_unitOfWork= unitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> BuscarUsuarios([FromQuery] BuscarUsuarios usuarios )
		{
			if(usuarios.Id != null || usuarios.Nome != null)
			{
				var user =	await _unitOfWork.Repositorio<Usuario>().Get(x => x.Id.Equals(usuarios.Id));
				return Ok(user);
			}
			var senha = "tete";
			var nome = "ttete";
			var email = "teste@teste.com.br";
			var resultado = await _comando.CadastrarUsuario(nome,email,senha);
			var lista = await _unitOfWork.Repositorio<Usuario>().GetTudo();
			return Ok(resultado);
		}
	}
}
