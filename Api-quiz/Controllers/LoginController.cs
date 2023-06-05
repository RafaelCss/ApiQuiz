using ApiQuiz.Model.Requisicoes.Login;
using AutoMapper;
using Dominio.Interface.Autenticacao;
using Dominio.Interface.Comando;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IComandoUsuario _comando;
		private readonly IServicoGeradorToken _geradorToken;

		public LoginController(IComandoUsuario comando,IMapper mapper,IServicoGeradorToken geradorToken)
		{
			_comando = comando;
			_geradorToken = geradorToken;
		}
		[HttpPost]
		public async Task<IActionResult> LogarUser([FromBody] LogarRequest user)
		{
			var validaUser = await _comando.LogarUsuario(user.Email,user.Senha);
			if(validaUser == null)
				return BadRequest("Usuário não encontrado");

			var token = _geradorToken.AddAutenticate(validaUser);

			return Ok(new
			{
				validaUser.Nome,
				validaUser.Email,
				token
			});
		}
	}
}
