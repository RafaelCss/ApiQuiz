using Dominio.Interface;
using Infra.Contexto;
using Infra.Repositorio.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigInfra
	{
		public static IServiceCollection AddConfigInfra(this IServiceCollection services,IConfiguration config)
		{ 
			var connectioDataBase = config.GetConnectionString("connectionMysql");
			services.AddDbContext<ContextoAplicacao>(opt =>
				opt.UseMySql(connectioDataBase, ServerVersion.AutoDetect(connectioDataBase)));

			services.AddScoped<IUnitOfWork,GenericUnitOfWork>();

			return services;

		}

	}
}
