using ApiQuiz.Model.Requisicoes.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{

		[HttpGet]
		public IActionResult BuscarUsuarios([FromQuery] BuscarUsuarios usuarios )
		{
			return Ok();
		}
	}
}
