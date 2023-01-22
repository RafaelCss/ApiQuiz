using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

