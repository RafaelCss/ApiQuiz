using Dominio.Interface.Comando.ComandoBase;
using Flunt.Notifications;

namespace Dominio.Services.Comandos
{
	public class Comando : Notifiable<Notification>, IComando
	{
		public void AddNotifications(IEnumerable<Notification> notifications)
		{
			throw new NotImplementedException();
		}
	}
}
