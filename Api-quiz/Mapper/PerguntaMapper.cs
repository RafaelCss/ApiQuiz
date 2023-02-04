using ApiQuiz.Model.Requisicoes.Perguntas;
using AutoMapper;
using Dominio.Entidades;

namespace ApiQuiz.Mapper
{
	public class PerguntaMapper :Profile
	{
		public PerguntaMapper() 
		{
			CreateMap<CadastrarPergunta,Pergunta>()
				.ForMember(x => x.Autor, 
				   opt => opt.MapFrom(
					  src => Guid.Parse(src.Autor)));
		}
	}
}
