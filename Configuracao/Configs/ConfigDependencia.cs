
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

			var key = Encoding.ASCII.GetBytes("5555wew5ewe9we5w9e45242688992322!@@#$%2115");

			services.AddAuthentication
				(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				}).AddJwtBearer( x =>
					{ 
						x.RequireHttpsMetadata= false;
						x.SaveToken = true;
						x.TokenValidationParameters = new TokenValidationParameters
						{
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = new SymmetricSecurityKey(key),
							ValidateIssuer = false,
							ValidateAudience = false
						};
	
					}
				);

			var assemblies = new[]
			{
				typeof(IConfiguration).Assembly,
			};

			return services;
		}


	}
}