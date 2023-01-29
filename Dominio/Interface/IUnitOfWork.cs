
using Dominio.Interface.Repositorio;

namespace Dominio.Interface
{
    public interface IUnitOfWork
	{
		void BeginTransaction();
		void Commit();
		void Rollback();
		IRepositorio<TEntity> Repositorio<TEntity>() where TEntity : class;
	}

}

