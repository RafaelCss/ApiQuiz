using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Configuracao.Configs
{
	public static class MyConfigServiceCollectionExtensions
	{
		public static IServiceCollection AddConfig(
			this IServiceCollection services,IConfiguration config)
		{
			var assemblies = new[]
			{
				typeof(IConfiguration).Assembly,
			};

			return services;
		}


	}
}