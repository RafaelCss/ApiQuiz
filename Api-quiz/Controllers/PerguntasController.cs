using ApiQuiz.Model.Requisicoes.Perguntas;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PerguntasController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		public PerguntasController(IUnitOfWork unitOfWork) 
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet]
		public async Task<IActionResult> BuscarPerguntas([FromQuery] BuscarPerguntas pergunta)
		{
			var resultado = await _unitOfWork.Repositorio<Pergunta>().GetTudo();
			return Ok(resultado);
		}


		[HttpPost]
		public async Task<IActionResult> CadastrarPergunta([FromBody] Pergunta pergunta)
		{


			 _unitOfWork.Repositorio<Pergunta>().Adicionar(pergunta);
			_unitOfWork.Commit();
			return Ok();

		}
	}
}
