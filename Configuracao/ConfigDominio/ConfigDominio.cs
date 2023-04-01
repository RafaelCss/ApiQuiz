using Dominio.Interface;
using Dominio.Interface.Comando;
using Dominio.Services.Comandos;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuracao.ConfigDominio
{
	public static class ConfigDominio
	{
		public static IServiceCollection AddConfigDominio(this IServiceCollection services,IConfiguration config)
		{
			services.AddTransient<IComandoUsuario,ComandoUsuario>();
			services.AddTransient<IComandoPerguntas,ComandoPerquntas>();
			return services;
		}
	}
}
