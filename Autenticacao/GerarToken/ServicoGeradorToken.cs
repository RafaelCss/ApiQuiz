using Dominio.Entidades;
using Dominio.Entidades.EntidadesMongo;
using Dominio.Interface.Autenticacao;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autenticacao.GerarToken
{
    public class ServicoGeradorToken : IServicoGeradorToken
    {
        private readonly IConfiguration _config;

        public ServicoGeradorToken(IConfiguration config)
        {
            _config= config;
        }

        public ServicoGeradorToken()
        {
        }
        public string AddAutenticate(UsuariosMongo user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject =
                new ClaimsIdentity(new[]{
                   //new Claim(ClaimTypes.Name, UsuariosMongo.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token).ToString();
        }
    }
}