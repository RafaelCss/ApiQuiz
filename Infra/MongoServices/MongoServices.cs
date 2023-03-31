 using Dominio.Interface.MongoRepositorio;
using Infra.MongoClient;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dominio.Services.MongoServices
{
	public class MongoServices<T> : IMongoRepositorio<T> where T : class 
	{
		private readonly IMongoClient _client;
		private readonly IMongoDatabase _database;

		public MongoServices(
			IOptions<ConnectMongo> connectMongo)
		{
			_client = new MongoClient(connectMongo.Value.ConnectionString);

			_database = _client.GetDatabase(connectMongo.Value.DatabaseName);
		}

		protected IMongoCollection<T> GetCollection(string collectionName)
		{
			return _database.GetCollection<T>(collectionName);
		}

		public async Task<List<T>> GetAsync(string collectionName) 
		{	var _collection =  GetCollection(collectionName);
			return await _collection.Find(_ => true).ToListAsync();
		}

		public async Task<T> GetAsyncId(string id,string collectionName)
		{
			var collection = GetCollection(collectionName);
			var filter = Builders<T>.Filter.Eq("_id",ObjectId.Parse(id));
			var result = await collection.FindAsync(filter);
			return await result.FirstOrDefaultAsync();
		}

		public async Task<T> GetAsyncFiltro(string collectionName,FilterDefinition<T> filter)
		{
			var collection = GetCollection(collectionName);
			var result =  collection.Find(filter).FirstOrDefault();
			return result;
		}
		public async Task CreateAsync(T newItem, string collectionName)
		{
			var collection = GetCollection(collectionName);
				await collection.InsertOneAsync(newItem); 
		}

		public async Task<bool> UpdateAsync(string id,T item,string collectionName)
		{
			var collection = GetCollection(collectionName);
			var filter = Builders<T>.Filter.Eq("_id",ObjectId.Parse(id));
			var result = await collection.ReplaceOneAsync(filter,item);
			return result.ModifiedCount > 0;
		}

		public async Task<bool> DeleteAsync(string id,string collectionName)
		{
			var collection = GetCollection(collectionName);
			var filter = Builders<T>.Filter.Eq("_id",ObjectId.Parse(id));
			var result = await collection.DeleteOneAsync(filter);
			return result.DeletedCount > 0;
		}

	}
}
