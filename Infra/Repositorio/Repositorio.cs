using Dominio.Interface.Repositorio;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;


namespace Infra.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
	{
		private readonly ContextoAplicacao m_Context ;
		private readonly DbSet<T> m_DbSet;

		public Repositorio(ContextoAplicacao context)
		{
			m_Context = context;
			m_DbSet = m_Context.Set<T>();
		}

		public async Task<List<T>> GetTudo(Expression<Func<T,bool>> predicate = null)
		{
			return await m_DbSet.ToListAsync();
		}

		public async Task<T> Get(Expression<Func<T,bool>> predicate)
		{
			var resultado = await m_DbSet.FirstOrDefaultAsync(predicate);
			return resultado;
		}

		public async Task<string> Adicionar(T entity)
		{
			var resultado = await m_DbSet.AddAsync(entity);
			return resultado.Entity.ToString();
				 
		}

		public void Atualizar(T entity)
		{
			m_DbSet.Attach(entity);
			((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity,(System.Data.Entity.EntityState)EntityState.Modified);
		}

		public void Deletar(T entity)
		{
			m_DbSet.Remove(entity);
		}

		public int Contar()
		{
			return m_DbSet.Count();
		}
	}
}
