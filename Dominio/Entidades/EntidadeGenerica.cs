using Dominio.Interface.EntidadeBase;
using Flunt.Notifications;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades
{
	public abstract class Entidade : Notifiable<Notification>, IEntidadeBase
	{
		[BsonId]
		public ObjectId _Id { get; set; }
		public DateTime DataDeCriacao { get; set; }

		public Entidade()
		{
			InserirData();
		}
		public void InserirData()
		{
			DataDeCriacao = DateTime.Now;
		}

		public void AddNotifications(IEnumerable<Notification> notifications)
		{
			foreach(var notification in notifications)
				AddNotification(notification);
		}

	}
}
