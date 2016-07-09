using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LiveloFlights.Domain
{
	public class Flight
	{
		[XmlElement("from")]
		public string From { get; set; }

		[XmlElement("landing")]
		public DateTime Landing { get; set; }

		[XmlElement("stops")]
		public int Stops { get; set; }

		[XmlElement("takeoff")]
		public DateTime TakeOff { get; set; }

		[XmlElement("to")]
		public string To { get; set; }
	}
}

