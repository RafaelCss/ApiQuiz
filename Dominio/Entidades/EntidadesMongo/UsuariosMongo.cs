using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Dominio.Entidades.EntidadesMongo
{
	public class UsuariosMongo
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = string.Empty;

		public string Nome { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Senha { get;  set; } = string.Empty;

	}
}
