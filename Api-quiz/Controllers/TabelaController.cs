using Dominio.Interface.Comando;
using Dominio.Interface.ServicoExterno;
using Dominio.Services.ExecuteServicoExternoPeriodicamente;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TabelaController : ControllerBase
	{
		private readonly IComandoTabela _comando;
		private readonly IServicoExterno _servicoExterno;
		public TabelaController(IComandoTabela comando,IServicoExterno servicoExterno)
		{
			_servicoExterno = servicoExterno;
			_comando = comando;
		}
		[HttpGet]
		public async Task<IActionResult> GetTabelaAsync()
		{
			var executarServico = new ExecuteServicoExternoPeriodicamente().ExecuteServicoExterno(_servicoExterno);
			var resultado = await _comando.BuscarDadosTabelaAsync();
			return Ok(resultado);
		}
	}

}
