
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades.PerguntasMongo
{
	public class PerguntasMongo
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string Titulo { get; set; }

		public string Assunto { get; set; }
		[BsonRepresentation(BsonType.ObjectId)]
		public string Autor_id { get; set; }
	}
}
