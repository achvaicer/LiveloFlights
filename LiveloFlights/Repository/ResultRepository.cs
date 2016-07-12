using LiveloFlights.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveloFlights.Repository
{
    public class ResultRepository : MongoRepository<Result>
    {
        public ResultRepository()
            : base(ConfigurationManager.AppSettings["MONGO-CONNECTION"],
            ConfigurationManager.AppSettings["MONGO-DBNAME"])
        {

        }

        public Result Single(string from, string to, DateTime leave, DateTime @return)
        {
            var collection = GetCollection();
            var filter = MakeFilter(from, to, leave, @return);
            return Single(filter);
        }


        private FilterDefinition<Result> MakeFilter(string from, string to, DateTime leave, DateTime @return)
        {
            return  Builders<Domain.Result>.Filter.Eq("From", from) &
                         Builders<Domain.Result>.Filter.Eq("To", to) &
                         Builders<Domain.Result>.Filter.Eq("Leave", leave) &
                         Builders<Domain.Result>.Filter.Eq("Return", @return);

        }

        private Result Single(FilterDefinition<Result> filter)
        {
            var collection = GetCollection();
            return collection.Find(filter).FirstOrDefault();
        }

        public override void Save(Result item)
        {
            var collection = GetCollection();
            var filter = MakeFilter(item.From, item.To, item.Leave, item.Return);
            var single = Single(filter);
            if (single == null)
                collection.InsertOne(item);
            else
            {
                item._id = single._id;
                collection.ReplaceOne(filter, item);
            }
        }
    }
}
