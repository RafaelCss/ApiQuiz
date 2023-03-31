using ApiQuiz.Model.Requisicoes.Perguntas;
using ApiQuiz.Model.Resposta.Perguntas;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PerguntasController : ControllerBase
	{
		private readonly IMapper _mapper;
		public PerguntasController( IMapper mapper) 
		{
			
			_mapper = mapper;
		}
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> BuscarPerguntas([FromQuery] BuscarPerguntas pergunta)
		{
		
			return Ok();
		}


		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CadastrarPergunta([FromBody] CadastrarPergunta pergunta)
		{ 
			
			return Ok();

		}
	}
}
