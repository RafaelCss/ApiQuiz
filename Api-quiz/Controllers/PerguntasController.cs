using Api_quiz.Model.Requisicoes.Perguntas;
using Api_quiz.Model.Resposta.Perguntas;
using Dominio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_quiz.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class PerguntasController : ControllerBase
	{
		[HttpGet("")]
		public IActionResult BuscarPerguntas([FromQuery] RequsicoesPerguntas perguntas)
		{
			return Ok(perguntas);
		}
	}
}
