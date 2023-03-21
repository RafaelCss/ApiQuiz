using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades.PerguntasMongo
{
	public class PerguntasMongo
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; private set; }

		public string Titulo { get; private set; }

		public string Assunto { get; private set; }

		[BsonId]
		public string Autor { get; private set; }

		public virtual Usuario Usuario { get; private set; }
	}
}
