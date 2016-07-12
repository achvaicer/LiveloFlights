using System;
using System.Collections.Generic;

namespace LiveloFlights
{
	interface IRepository<TEntity> where TEntity : class, new()
	{
        IEnumerable<TEntity> All();
		void Delete(object key);
		void Save(TEntity item);
		TEntity Single(object key);
	}
}

