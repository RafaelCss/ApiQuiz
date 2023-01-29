using ApiQuiz.Model.Requisicoes.Usuarios;
using AutoMapper;
using Dominio.Entidades;

namespace ApiQuiz.Mapper
{
	public class UsuarioMapper : Profile
	{
		public UsuarioMapper()
		{
			CreateMap<BuscarUsuarios,Usuario>();
		}
	}
}
