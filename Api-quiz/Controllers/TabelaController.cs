using ApiQuiz.Model.Requisicoes.Perguntas;
using Dominio.Interface.Comando;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TabelaController : ControllerBase
	{

		private readonly IComandoUsuario _comando;

		public TabelaController()
		{

		}
		[HttpGet]
		//[Authorize]
		public async Task<IActionResult> GetTabelaAsync([FromQuery] BuscarPerguntas pergunta)
		{
			var resultado = await _perguntas.BuscarPerguntas("teste","teste");
			return Ok(resultado);
		}
	}

}
