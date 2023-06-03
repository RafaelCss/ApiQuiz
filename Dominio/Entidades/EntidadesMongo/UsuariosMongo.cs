using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades.EntidadesMongo
{
	public class UsuariosMongo
	{
		[BsonId]
		public ObjectId Id { get; set; }

		public string Nome { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Senha { get; set; } = string.Empty;

	}
}
