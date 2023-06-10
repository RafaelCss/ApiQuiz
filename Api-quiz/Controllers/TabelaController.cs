using AutoMapper;
using Dominio.Interface.Comando;
using Dominio.Interface.ServicoExterno;
using Microsoft.AspNetCore.Mvc;

namespace ApiQuiz.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TabelaController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IComandoTabela _comando;
		private readonly IServicoExterno _servicoExterno;
		public TabelaController(IComandoTabela comando,IServicoExterno servicoExterno,IMapper mapper)
		{
			_servicoExterno = servicoExterno;
			_comando = comando;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> GetTabelaAsync()
		{
			await _servicoExterno.FazerBusca();
			var resultado = await _comando.BuscarDadosTabelaAsync();
			//var mapperTabela = _mapper.Map<TabelaViewModel>(resultado);
			return Ok(resultado);
		}
	}

}
