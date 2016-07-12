using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveloFlights.Domain
{
	public class Flight
	{
		[JsonProperty("from")]
		public string From { get; set; }

		[JsonProperty("landing")]
		public DateTime Landing { get; set; }

		[JsonProperty("stops")]
		public int Stops { get; set; }

		[JsonProperty("takeoff")]
		public DateTime TakeOff { get; set; }

		[JsonProperty("to")]
		public string To { get; set; }

        public IList<Leg> Legs { get; set; }
    }
}

