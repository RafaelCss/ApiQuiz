namespace Dominio.Entidades
{
	internal class CustomNotification
	{
		private string key;
		private string message;
		private DateTime now;

		public CustomNotification(string key,string message,DateTime now)
		{
			this.key = key;
			this.message = message;
			this.now = now;
		}
	}
}