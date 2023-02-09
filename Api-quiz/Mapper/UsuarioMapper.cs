using ApiQuiz.Model.Requisicoes.Usuarios;
using ApiQuiz.Model.Resposta.Usuarios;
using AutoMapper;
using Dominio.Entidades;

namespace ApiQuiz.Mapper
{
	public class UsuarioMapper : Profile
	{
		public UsuarioMapper()
		{
			CreateMap<BuscarUsuarios,Usuario>();
			CreateMap<Usuario,ViewsUsuarios>();
		}
	}
}
