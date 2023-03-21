using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuracao.ConfigInfra
{
	public static class ConfigMySql 
	{
		public static IServiceCollection AddConfigInfra(this IServiceCollection services,IConfiguration config)
		{
			var connectioDataBase = config.GetConnectionString("connectionMysql");

			services.AddDbContext<ContextoAplicacao>(opt =>
				opt.UseLazyLoadingProxies()
						.UseMySql(connectioDataBase,ServerVersion.AutoDetect(connectioDataBase), 
									opts => opts.MigrationsAssembly("Infra")));

			return services;

		}

	}
}
