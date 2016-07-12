using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveloFlights.Domain
{
    public class Result
    {
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }

        [JsonProperty("airlines")]
		public IList<Airline> Airlines { get; set; }

		[JsonProperty("airports")]
		public IList<Airport> Airports { get; set; }

        [JsonProperty("recommendations")]
		public IList<Recommendation> Recommendations { get; set; }

        [JsonIgnore]
        public string From { get; set; }
        [JsonIgnore]
        public string To { get; set; }
        [JsonIgnore]
        public DateTime Leave { get; set; }
        [JsonIgnore]
        public DateTime Return { get; set; }
    }
}