using Microsoft.Extensions.DependencyInjection;
using Infra.MongoClient;
using Microsoft.Extensions.Configuration;
using Dominio.Interface.MongoRepositorio;
using Dominio.Services.MongoServices;
using Dominio.Entidades.EntidadesMongo;

namespace Configuracao.MongoConfig
{
	public static class MongoConfig
	{
		public static IServiceCollection AddMongoConfig(this IServiceCollection services,IConfiguration config)
		{
			services.AddTransient(typeof(IMongoRepositorio<>),typeof(MongoServices<>)); 
			services.Configure<ConnectMongo>(config.GetSection("MongoDatabase"));
			return services;
		}
	}
}
