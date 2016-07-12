using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LiveloFlights
{
	public class MongoRepository : IRepository
	{
		//private readonly RepositoryKeys _keys;
		private readonly string _connectionString;
		private readonly string _databaseName;

		private readonly MongoClient _client;
		private readonly IMongoDatabase _db;

		public MongoRepository(string connectionString, string databaseName)
		{
			//_keys = keys;
			_connectionString = connectionString;
			_databaseName = databaseName;

			_client = new MongoClient(_connectionString);
			_db = _client.GetDatabase(_databaseName);

		}

		public TEntity Single<TEntity>(object key) where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			var filter = Builders<TEntity>.Filter.Eq("_id", key);


			return collection.Find(filter).First();
		}

		public IEnumerable<TEntity> All<TEntity>() where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			return collection.Find(new BsonDocument()).ToEnumerable();
		}



		public void Save<TEntity>(TEntity item) where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();
			collection.InsertOne(item);
		}

		public void Delete<TEntity>(object key) where TEntity : class, new()
		{
			var collection = GetCollection<TEntity>();

			var filter = Builders<TEntity>.Filter.Eq("_id", BsonValue.Create(key));
			collection.DeleteOne(filter);
		}


		IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : class, new()
		{
			return _db.GetCollection<TEntity>(typeof(TEntity).Name);
		}
	}
}

