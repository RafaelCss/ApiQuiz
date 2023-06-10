using ApiQuiz.Model.Resposta.Tabela;
using AutoMapper;
using Dominio.Entidades.EntidadesMongo;

namespace ApiQuiz.Mapper
{
	public class TabelaCampeonatoMapper : Profile
	{
		public TabelaCampeonatoMapper()
		{
			CreateMap<TabelaCampeonato,TabelaViewModel>()
				.ForMember(dest => dest.Time,opts => opts.MapFrom(src => src.Time));
		}
	}
}
