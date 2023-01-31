
using Dominio.Interface.Repositorio;

namespace Dominio.Interface
{
    public interface IUnitOfWork
	{
		void BeginTransaction();
		Task<int> Commit();
		void Rollback();
		IRepositorio<TEntity> Repositorio<TEntity>() where TEntity : class;
	}

}

