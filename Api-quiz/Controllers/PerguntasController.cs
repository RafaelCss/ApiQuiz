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
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public PerguntasController(IUnitOfWork unitOfWork, IMapper mapper) 
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> BuscarPerguntas([FromQuery] BuscarPerguntas pergunta)
		{
			var busca = await _unitOfWork.Repositorio<Pergunta>().GetTudo();
			var resultado = _mapper.Map<List<ViewsPerguntas>>(busca); 
			return Ok(resultado);
		}


		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CadastrarPergunta([FromBody] CadastrarPergunta pergunta)
		{ 
			var mapper = _mapper.Map<Pergunta>(pergunta);
			 _unitOfWork.Repositorio<Pergunta>().Adicionar(mapper);
			 var resultado = await _unitOfWork.Commit();
			return Ok(resultado);

		}
	}
}
