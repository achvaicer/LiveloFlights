using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LiveloFlights.Domain
{
    public class Money
    {
        [XmlElement("$")]
        public string Value { get; set; }
        public string Currency { get; set; }
    }
}
