using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveloFlights
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://www.pontoslivelo.com.br/livelo-travels/");

            var request = new RestRequest("flights", Method.GET);


            request.AddHeader("CVC-AGENT-SINE", "1");
            request.AddHeader("CVC-BRANCH-CODE", "1000");
            request.AddHeader("LIVELO-LOYALTY-KEY", "");

            request.AddParameter("roundTrip", true);
            request.AddParameter("fromIATA", "RIO");
            request.AddParameter("toIATA", "MIA");
            request.AddParameter("leaveDate", "2017-01-14");
            request.AddParameter("returnDate", "2017-01-28");
            request.AddParameter("nonstop", false);
            request.AddParameter("adtQty", "2");
            request.AddParameter("chdQty", "1");
            request.AddParameter("infQty", "1");
            request.AddParameter("international", "true");
            request.AddParameter("fromId", "1");
            request.AddParameter("toId", "1");
            request.AddParameter("limit", "100");
            request.AddParameter("offset", "1");
            request.AddParameter("sort", "byLowestPrice");
            request.AddParameter("departuresQ", "Rio");
            request.AddParameter("arrivalsQ", "Mia");

            var response = client.Get(request);

        }
    }
}
