using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LiveloFlights.Domain
{
    public class Airline
    {
		[XmlElement("iata")]
        public string IATA { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
