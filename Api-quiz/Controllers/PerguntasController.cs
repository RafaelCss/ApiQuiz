using Api_quiz.Model.Requisicoes.Perguntas;
using Api_quiz.Model.Resposta.Perguntas;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Http;
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
			var perguntas = _uow.Repositorio<Pergunta>().GetTudo();
			return Ok(perguntas);
		}


		[HttpPost]
		public async Task<IActionResult> CadastrarPergunta(Pergunta pergunta)
		{
			 _uow.Repositorio<Pergunta>().Adicionar(pergunta);
			_uow.Commit();
			return Ok(pergunta);
		}
	}
}
