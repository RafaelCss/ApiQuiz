using Dominio.Interface;
using Infra.Repositorio.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigDominio
	{
		public static IServiceCollection AddConfigDominio(this IServiceCollection services,IConfiguration config)
		{
			services.AddScoped<IUnitOfWork,GenericUnitOfWork>();
			return services;

		}
	}
}
