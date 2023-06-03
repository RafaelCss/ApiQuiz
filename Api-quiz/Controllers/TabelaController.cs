using ApiQuiz.Model.Requisicoes.Perguntas;
using Dominio.Interface.Comando;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TabelaController : ControllerBase
	{

		private readonly IComandoTabela _comando;

		public TabelaController(IComandoTabela comando)
		{
			_comando = comando;
		}
		[HttpGet]
		public async Task<IActionResult> GetTabelaAsync([FromQuery] BuscarPerguntas pergunta)
		{
			var resultado = await _comando.BuscarDadosTabelaAsync();
			return Ok(resultado);
		}
	}

}
