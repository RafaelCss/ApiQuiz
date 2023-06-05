using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades.EntidadesMongo
{
	public class TabelaCampeonato
	{
		[BsonId]
		public ObjectId Id { get; set; }

		[BsonElement("posicao")]
		public int Posicao { get; set; }

		[BsonElement("pontos")]
		public int Pontos { get; set; }

		[BsonElement("time")]
		public Time Time { get; set; }

		[BsonElement("jogos")]
		public int Jogos { get; set; }

		[BsonElement("vitorias")]
		public int Vitorias { get; set; }

		[BsonElement("empates")]
		public int Empates { get; set; }

		[BsonElement("derrotas")]
		public int Derrotas { get; set; }

		[BsonElement("gols_pro")]
		public int GolsPro { get; set; }

		[BsonElement("gols_contra")]
		public int GolsContra { get; set; }

		[BsonElement("saldo_gols")]
		public int SaldoGols { get; set; }

		[BsonElement("aproveitamento")]
		public int Aproveitamento { get; set; }

		[BsonElement("variacao_posicao")]
		public int VariacaoPosicao { get; set; }

		[BsonElement("ultimos_jogos")]
		public List<string> UltimosJogos { get; set; }
	}
}
