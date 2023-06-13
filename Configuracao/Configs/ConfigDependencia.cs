
using Autenticacao.CriptografarSenha;
using Autenticacao.GerarToken;
using Dominio.Interface.Autenticacao;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Configuracao.Configs
{
	public static class MyConfigServiceCollectionExtensions
	{
		public static IServiceCollection AddConfig(this IServiceCollection services,IConfiguration config)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddTransient<IServicoGeradorToken,ServicoGeradorToken>();
			services.AddTransient<ICriptografarSenha,CriptografarSenha>();

			var key = Encoding.ASCII.GetBytes(config["Jwt:SecretKey"]);

			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder =>
					{
						builder.WithOrigins("*")
							   .AllowAnyHeader()
							   .AllowAnyMethod();
					});
			});

			services.AddAuthentication
				(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				}).AddJwtBearer(x =>
					{
						x.RequireHttpsMetadata = false;
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