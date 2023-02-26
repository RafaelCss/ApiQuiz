using ApiQuiz.Model.Requisicoes.Login;
using Autenticacao;
using AutoMapper;
using Dominio.Interface.Comando;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IComandoUsuario _comando;
		public LoginController(IComandoUsuario comando,IMapper mapper)
		{
			_comando = comando;
		}
		[HttpPost]
		public async Task<IActionResult> LogarUser([FromBody] LogarView user)
		{
			var autenticacao = new AutenticacaoUsuario();
			var validaUser = await _comando.BuscarUsuario("teste",user.Email,user.Senha);
			if(validaUser == null)
				return BadRequest("Usuário não encontrado");

		     var token = autenticacao.AddAutenticate(validaUser);

			return Ok(new {
				user.Email,
				validaUser.Nome,
				token
			});
		}
	}
}
