using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades
{
    public class Time
    {
        [BsonElement("time_id")]
        public int TimeId { get; set; }

        [BsonElement("nome_popular")]
        public string NomePopular { get; set; }

        [BsonElement("sigla")]
        public string Sigla { get; set; }

        [BsonElement("escudo")]
        public string Escudo { get; set; }

    }
}
