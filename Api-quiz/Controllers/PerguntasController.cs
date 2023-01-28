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


		[HttpGet]
		public async Task<IActionResult> BuscarPerguntas([FromQuery] BuscarPerguntas pergunta)
		{
			var resultado = await _uow.Repositorio<Usuario>().GetTudo();
			return Ok(resultado);
		}


		[HttpPost]
		public async Task<IActionResult> CadastrarPergunta([FromBody] CadastrarPergunta pergunta)
		{
			var user = new Usuario("Teste", "teste@teste.com", "5555");

			  _uow.Repositorio<Usuario>().Adicionar(user);
			  _uow.Commit();
			//var teste = "ok";

			return Ok(user);

		}
	}
}
