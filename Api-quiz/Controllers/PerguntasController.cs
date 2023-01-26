using Api_quiz.Model.Requisicoes.Perguntas;
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
			var resultado = _uow.Repositorio<Pergunta>().GetTudo();
			return Ok(resultado);
		}


		[HttpPost("")]
		public  IActionResult CadastrarPergunta([FromBody] Usuario pergunta)
		{
			// _uow.Repositorio<Usuario>().Adicionar(pergunta);
			var teste = "ok";
			return Ok($"cadastro realizado {teste}");
		}
	}
}
