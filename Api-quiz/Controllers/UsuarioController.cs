using ApiQuiz.Model.Requisicoes.Usuarios;
using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Interface.Comando;
using Dominio.Respostas;
using Dominio.Services.Comandos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		private readonly IComandoUsuario _comando;
	
		public UsuarioController(IComandoUsuario comando)
		{
			_comando= comando;
		}

		[HttpGet]
		public async Task<IActionResult> BuscarUsuarios([FromQuery] BuscarUsuarios usuarios )
		{
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> CadastrarUsuarios([FromBody] CadastrarUsuario usuarios)
		{
			var resultado = await _comando.CadastrarUsuario(usuarios.Nome,usuarios.Email,usuarios.Senha);
	
			return Ok(resultado);
		}
	}
}
