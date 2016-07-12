using RestSharp;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LiveloFlights
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://www.pontoslivelo.com.br/livelo-travels/");

            var key = ConfigurationManager.AppSettings["LIVELO-LOYALTY-KEY"];
            var winner = new Domain.Recommendation() { FarePerPassenger = new Domain.Money { Value = decimal.MaxValue } };

            
            for(var leave = new DateTime(2017, 01, 11); leave < new DateTime(2017, 01, 18); leave = leave.AddDays(1))
            {
                Parallel.For(10, 16, (days) =>
                {
                    var returnDate = leave.AddDays(days);

                    var request = new RestRequest("flights", Method.GET);


                    request.AddHeader("CVC-AGENT-SINE", "1");
                    request.AddHeader("CVC-BRANCH-CODE", "1000");
                    request.AddHeader("LIVELO-LOYALTY-KEY", key);

                    request.AddParameter("roundTrip", true);
                    request.AddParameter("fromIATA", "RIO");
                    request.AddParameter("toIATA", "CUN");
                    request.AddParameter("leaveDate", leave.ToString("yyyy-MM-dd"));
                    request.AddParameter("returnDate", returnDate.ToString("yyyy-MM-dd"));
                    request.AddParameter("nonstop", false);
                    request.AddParameter("adtQty", "2");
                    request.AddParameter("chdQty", "1");
                    request.AddParameter("infQty", "1");
                    request.AddParameter("international", "true");
                    request.AddParameter("fromId", "1");
                    request.AddParameter("toId", "1");
                    request.AddParameter("limit", "10");
                    request.AddParameter("offset", "1");
                    request.AddParameter("sort", "byLowestPrice");
                    
                    var response = client.Get<Domain.Result>(request);

                    var result = JsonConvert.DeserializeObject<Domain.Result>(response.Content);
                    if (result == null || result.Recommendations == null || !result.Recommendations.Any()) return;

                    var first = result.Recommendations.First();

                    if (first.FarePerPassenger.Value < winner.FarePerPassenger.Value)
                        winner = first;
                    Console.WriteLine("{0:N0}: {1:dd/MMM/yyyy} -> {2:dd/MMM/yyyy}", first.FarePerPassenger.Value, leave, returnDate);
                });


               
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lowest {0:N0}", winner.FarePerPassenger.Value);
            Console.Read();

        }
    }
}
