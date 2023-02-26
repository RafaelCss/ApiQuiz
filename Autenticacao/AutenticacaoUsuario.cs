
using Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autenticacao
{
	public class AutenticacaoUsuario
	{

		public string AddAutenticate(Usuario user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("5555wew5ewe9we5w9e45242688992322!@@#$%2115");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject =
				new ClaimsIdentity(new []{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.Email.ToString()),
				}),
				Expires= DateTime.UtcNow.AddHours(12),
				SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(key),
				SecurityAlgorithms.HmacSha256Signature)
				
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token).ToString();
		}
	}
}