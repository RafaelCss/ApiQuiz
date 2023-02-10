using ApiQuiz.Model.Requisicoes.Perguntas;
using ApiQuiz.Model.Resposta.Perguntas;
using AutoMapper;
using Dominio.Entidades;

namespace ApiQuiz.Mapper
{
	public class PerguntaMapper:Profile
	{
		public PerguntaMapper() 
		{
			CreateMap<CadastrarPergunta,Pergunta>()
				.ForMember(x => x.Autor, 
				   opt => opt.MapFrom(
					  src => Guid.Parse(src.Autor)));

			CreateMap<Pergunta,ViewsPerguntas>()
				.ForMember(x => x.Autor, 
					opt => opt.MapFrom(autor => autor.Usuario));
		}
	}
}
