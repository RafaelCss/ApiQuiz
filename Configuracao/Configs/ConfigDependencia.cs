
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace Configuracao.Configs
{
	public static class MyConfigServiceCollectionExtensions
	{
		public static IServiceCollection AddConfig(
			this IServiceCollection services,IConfiguration config)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
			var assemblies = new[]
			{
				typeof(IConfiguration).Assembly,
			};
			
			return services;
		}


	}
}