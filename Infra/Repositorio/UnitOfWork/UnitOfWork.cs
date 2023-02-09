using Dominio.Interface;
using Dominio.Interface.Repositorio;
using Infra.Contexto;
using System.Data.Common;


namespace Infra.Repositorio.UnitOfWork
{
    public class GenericUnitOfWork : IUnitOfWork
	{
		private readonly ContextoAplicacao _context;
		private DbTransaction _transaction = null;
		private Dictionary<Type,object> _repositories;

		public GenericUnitOfWork(ContextoAplicacao context)
		{
			_context = context;
			_repositories = new Dictionary<Type,object>();
		}

		public IRepositorio<TEntity>? Repositorio<TEntity>() where TEntity : class
		{
			if(_repositories.ContainsKey(typeof(TEntity)) == true)
			{
				return _repositories[typeof(TEntity)] as IRepositorio<TEntity>;
			}

			IRepositorio<TEntity> repository = new Repositorio<TEntity>(_context);
			_repositories.Add(typeof(TEntity),repository);
			return repository;
		}

		public void BeginTransaction()
		{
			_transaction = (DbTransaction)_context.Database.BeginTransaction();
		}

		public async Task<int> Commit()
		{
			try
			{
				var resultado = await _context.SaveChangesAsync();
				return resultado;
			}
			catch
			{
				_transaction.Rollback();
				throw;
			}
		}

		public void Rollback()
		{
			_transaction.Rollback();
		}

	}
}	
