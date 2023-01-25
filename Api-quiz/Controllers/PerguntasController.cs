using Api_quiz.Model.Requisicoes.Perguntas;
using Api_quiz.Model.Resposta.Perguntas;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api_quiz.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class PerguntasController : ControllerBase
	{
		private readonly IUnitOfWork _uow;

		public PerguntasController(IUnitOfWork uow) 
		{
			_uow = uow;
		}


		[HttpGet("")]
		public IActionResult BuscarPerguntas([FromQuery] BuscarPerguntas pergunta)
		{
			return Ok(pergunta);
		}


		[HttpPost]
		public IActionResult CadastrarPergunta(CadastrarPergunta pergunta)
		{

			return Ok(pergunta);
		}
	}
}
