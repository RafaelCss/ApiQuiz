using Dominio.Interface.ServicoExterno;

namespace Dominio.Services.ExecuteServicoExternoPeriodicamente
{
	public class ExecuteServicoExternoPeriodicamente
	{
		private DateTime ultimaChamada = DateTime.MinValue;
		public async Task ExecuteServicoExterno(IServicoExterno _servicoExterno)
		{
			await Task.Run(async () =>
			{
				while(true)
				{
					if(DateTime.UtcNow - ultimaChamada >= TimeSpan.FromHours(3))
					{
						await _servicoExterno.FazerBusca();
						ultimaChamada = DateTime.UtcNow;
					}

					await Task.Delay(TimeSpan.FromMinutes(15)); // Espera 15 minutos antes de verificar novamente
				}
			});
		}
	}
}
