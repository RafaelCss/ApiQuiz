
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades.PerguntasMongo
{
	public class PerguntasMongo
	{
		[BsonId]
		public ObjectId Id { get; set; }

		public string Titulo { get; set; }

		public string Assunto { get; set; }

		public ObjectId? Autor_id { get; set; }
	}
}
