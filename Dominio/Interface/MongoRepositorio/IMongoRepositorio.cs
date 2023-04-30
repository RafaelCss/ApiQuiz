

using MongoDB.Driver;

namespace Dominio.Interface.MongoRepositorio
{
	public interface IMongoRepositorio<T>
	{
		Task<List<T>> GetAsync(string collectionName);
		Task<T> GetAsyncId(string id,string collectionName);
		Task CreateAsync(T item,string collectionName);
		Task<bool> UpdateAsync(string id,UpdateDefinition<T> update,string collectionName);
		Task<bool> DeleteAsync(string id,string collectionName);
		Task<T> GetAsyncFiltro(string collectionNam,FilterDefinition<T> filter);
	}
}
