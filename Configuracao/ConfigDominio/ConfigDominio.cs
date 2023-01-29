using Dominio.Interface;
using Dominio.Interface.Comando;
using Dominio.Services.Comandos;
using Infra.Repositorio.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuracao.ConfigDominio
{
	public static class ConfigDominio
	{
		public static IServiceCollection AddConfigDominio(this IServiceCollection services,IConfiguration config)
		{
			services.AddTransient<IUnitOfWork,GenericUnitOfWork>();
			services.AddTransient<IComandoUsuario,ComandoUsuario>();
			return services;
		}
	}
}
