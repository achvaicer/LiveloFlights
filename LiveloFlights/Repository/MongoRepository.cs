using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LiveloFlights
{
	public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
		//private readonly RepositoryKeys _keys;
		private readonly string _connectionString;
		private readonly string _databaseName;

		private readonly MongoClient _client;
		protected readonly IMongoDatabase _db;

		public MongoRepository(string connectionString, string databaseName)
		{
			//_keys = keys;
			_connectionString = connectionString;
			_databaseName = databaseName;

			_client = new MongoClient(_connectionString);
			_db = _client.GetDatabase(_databaseName);

		}

        public void Drop()
        {
            _db.DropCollection(typeof(TEntity).Name);
        }

        public void Create()
        {
            _db.CreateCollection(typeof(TEntity).Name);
        }

		public TEntity Single(object key) 
		{
			var collection = GetCollection();
			var filter = Builders<TEntity>.Filter.Eq("_id", key);


			return collection.Find(filter).First();
		}

		public IEnumerable<TEntity> All() 
		{
			var collection = GetCollection();
			return collection.Find(new BsonDocument()).ToEnumerable();
		}



		public virtual void Save(TEntity item) 
		{
			var collection = GetCollection();
            collection.InsertOne(item);
		}

		public void Delete(object key) 
		{
			var collection = GetCollection();

			var filter = Builders<TEntity>.Filter.Eq("_id", BsonValue.Create(key));
			collection.DeleteOne(filter);
		}


		protected IMongoCollection<TEntity> GetCollection() 
		{
			return _db.GetCollection<TEntity>(typeof(TEntity).Name);
		}
	}
}

