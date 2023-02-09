using System.Linq.Expressions;

namespace Dominio.Interface.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task<List<T>> GetTudo(Expression<Func<T, bool>> predicate = null);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<string> Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(T entity);
        int Contar();
    }
}