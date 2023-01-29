using Flunt.Notifications;


namespace Dominio.Interface.EntidadeBase
{
    public interface IEntidadeBase : INotifiable
    {
        public Guid Id { get; set; }
        public DateTime DataDeCriacao { get; set; }
        protected void InserirData();
    }
}
