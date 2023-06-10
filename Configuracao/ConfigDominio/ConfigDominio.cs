using Dominio.Interface.Comando;
using Dominio.Interface.ServicoExterno;
using Dominio.Services.Comandos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicoExterno;

namespace Configuracao.ConfigDominio
{
	public static class ConfigDominio
	{
		public static IServiceCollection AddConfigDominio(this IServiceCollection services,IConfiguration config)
		{
			services.AddTransient<IComandoUsuario,ComandoUsuario>();
			services.AddTransient<IComandoPerguntas,ComandoPerquntas>();
			services.AddTransient<IComandoTabela,ComandoTabela>();
			services.AddTransient<IServicoExterno,ServicoExternoBusca>();
			return services;
		}
	}
}
