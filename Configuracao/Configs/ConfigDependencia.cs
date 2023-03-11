
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Dominio.Interface.Autenticacao;
using Autenticacao.GerarToken;
using Autenticacao.CriptografarSenha;

namespace Configuracao.Configs
{
    public static class MyConfigServiceCollectionExtensions
	{
		public static IServiceCollection AddConfig(this IServiceCollection services,IConfiguration config)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddTransient<IServicoGeradorToken, ServicoGeradorToken>();	
			services.AddTransient<ICriptografarSenha, CriptografarSenha>();

			var key = Encoding.ASCII.GetBytes(config["Jwt:SecretKey"]);

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