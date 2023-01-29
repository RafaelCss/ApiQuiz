namespace Dominio.Services.Notificacoes
{
    public class CustomNotification
    {
        private string key;
        private string message;

        public CustomNotification(string key, string message)
        {
            this.key = key;
            this.message = message;
        }
    }
}