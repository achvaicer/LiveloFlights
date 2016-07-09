using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LiveloFlights.Domain
{
    public class Recommendation
    {
		public Recommendation()
		{

		}
		[XmlElement("airline")]
        public string Airline { get; set; }

        [XmlElement("farePerPassenger")]
        public Money FarePerPassenger { get; set; }

        [XmlElement("leaveList")]
		public IList<Flight> Flights { get; set; }
    }
}
