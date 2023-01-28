using Dominio.Interface;
using Flunt.Notifications;


namespace Dominio.Entidades
{
	public abstract class Entidade : Notifiable<Notification>, IEntidadeBase
	{
		public Guid Id { get; set; }
		public DateTime DataDeCriacao { get; set; }

		public Entidade()
		{
			InserirData();
		}
		public void InserirData()
		{
			DataDeCriacao= DateTime.Now;
		}

		public void AddNotifications(IEnumerable<Notification> notifications)
		{
			foreach(var notification in notifications)
				AddNotification(notification);
		}

	}
}
