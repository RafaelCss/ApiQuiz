using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades.EntidadesMongo
{
	public class TabelaCampenato
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public int Posicao { get; set; }
		public int Pontos { get; set; }
		public IReadOnlyCollection<Time> Time { get; set; }
		public int Jogos { get; set; }
		public int Vitorias { get; set; }
		public int Empates { get; set; }
		public int Derrotas { get; set; }
		public int GolsPro { get; set; }
		public int GolsContra { get; set; }
		public int SaldoGols { get; set; }
		public int Aproveitamento { get; set; }
		public int VariacaoPosicao { get; set; }
		public IEnumerable<string> UltimosJogos { get; set; }
	}
}
