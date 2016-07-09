using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LiveloFlights.Domain
{
    public class Money
    {
		[JsonProperty("$")]
		public decimal Value { get; set; }
    }
}
