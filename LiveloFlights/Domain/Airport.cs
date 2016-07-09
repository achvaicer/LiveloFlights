using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LiveloFlights.Domain
{
    public class Airport
    {
		[XmlElement("cityName")]
        public string City { get; set; }
        [XmlElement("iata")]
        public string IATA { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
