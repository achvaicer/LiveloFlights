using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LiveloFlights.Domain
{
    public class Result
    {
		[JsonProperty("airlines")]
		public IList<Airline> Airlines { get; set; }

		[JsonProperty("airports")]
		public IList<Airport> Airports { get; set; }

        [JsonProperty("recommendations")]
		public IList<Recommendation> Recommendations { get; set; }
    }
}