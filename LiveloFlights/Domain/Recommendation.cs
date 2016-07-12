using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LiveloFlights.Domain
{
    public class Recommendation
    {
		public Recommendation()
		{

		}
		[JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("farePerPassenger")]
        public Money FarePerPassenger { get; set; }

        [JsonProperty("leaveList")]
		public IList<Flight> Flights { get; set; }
    }
}
