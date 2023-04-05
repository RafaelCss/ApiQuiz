﻿using ApiQuiz.Model.Requisicoes.Perguntas;
using ApiQuiz.Model.Resposta.Perguntas;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interface;
using Dominio.Interface.Comando;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PerguntasController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IComandoPerguntas _perguntas;
		public PerguntasController( IMapper mapper,IComandoPerguntas perguntas)
		{
			_perguntas = perguntas;
			_mapper = mapper;
		}
		[HttpGet]
		[Authorize]
		public async Task<IActionResult> BuscarPerguntas([FromQuery] BuscarPerguntas pergunta)
		{
			var resultado = await _perguntas.BuscarPerguntas("teste","teste");
			return Ok(resultado);
		}


		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CadastrarPergunta([FromBody] CadastrarPergunta pergunta)
		{
			var resultado = await _perguntas.CadastrarPergunta(pergunta.Titulo,pergunta.Assunto,pergunta.Autor_id);
			return Ok(resultado);

		}
	}
}
