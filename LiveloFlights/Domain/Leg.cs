using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveloFlights.Domain
{
    public class Leg
    {
        [JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("airlineName")]
        public string AirlineName { get; set; }

        [JsonProperty("flightNumber")]
        public string FlightNumber { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("takeoff")]
        public DateTime TakeOff { get; set; }

        [JsonProperty("landing")]
        public DateTime Landing { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("aircraftCode")]
        public string AircraftCode { get; set; }

        [JsonProperty("tariffClass")]
        public string TariffClass { get; set; }

        [JsonProperty("TariffClassName")]
        public string tariffClassName { get; set; }

        [JsonProperty("tariffBase")]
        public string TariffBase { get; set; }

        [JsonProperty("dealer")]
        public string Dealer { get; set; }

        [JsonProperty("seatClass")]
        public string SeatClass { get; set; }

        [JsonProperty("marriedFlight")]
        public string MarriedFlight { get; set; }
    }
}
