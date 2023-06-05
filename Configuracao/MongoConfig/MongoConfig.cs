using Dominio.Interface.MongoRepositorio;
using Dominio.Services.MongoServices;
using Infra.MongoClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicoExterno;

namespace Configuracao.MongoConfig
{
	public static class MongoConfig
	{
		public static IServiceCollection AddMongoConfig(this IServiceCollection services,IConfiguration config)
		{
			services.AddTransient(typeof(IMongoRepositorio<>),typeof(MongoServices<>));
			services.AddTransient(typeof(ServicoExternoBusca),typeof(ServicoExternoBusca));
			services.Configure<ConnectMongo>(config.GetSection("MongoDatabase"));
			return services;
		}
	}
}
