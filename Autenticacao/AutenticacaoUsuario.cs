
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autenticacao
{
	public static class AutenticacaoUsuario
	{
		private static readonly IConfiguration _config;


		public static string Autenticate()
		{
			var claims = new[]
			  {
					new Claim(JwtRegisteredClaimNames.Sub, "username"),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

			var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JwtSettings:SecretKey"]));
			var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: null,
				audience: null,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(30),
				signingCredentials: creds
				);

			return token.ToString();
		}
	}
}