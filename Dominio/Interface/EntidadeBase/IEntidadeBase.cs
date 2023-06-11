using Flunt.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Interface.EntidadeBase
{
	public interface IEntidadeBase : INotifiable
	{

		[BsonId]
		public ObjectId _Id { get; set; }
		public DateTime DataDeCriacao { get; set; }
		protected void InserirData();
	}
}
