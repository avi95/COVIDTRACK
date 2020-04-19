using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace COVID19TRACK.Models
{
    public class getCOVIDdata
    {
        public List<regional> getData(out int total, out float death, out float discharged, out DateTime lastRefreshed)
        {
            var client = new RestClient("https://api.rootnet.in/covid19-in/stats/latest");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "efd6234b-3e85-42f4-6e52-67c80c45f567");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            PocoCourse items = JsonConvert.DeserializeObject<PocoCourse>(response.Content);
            total = items.data.summary.total;
            death = items.data.summary.deaths;
            discharged = items.data.summary.discharged;
            lastRefreshed = items.lastRefreshed;
            return items.data.regional.OrderByDescending(x => x.totalConfirmed).ToList();
        }

        public string getTestingData()
        {
            var client = new RestClient("https://api.rootnet.in/covid19-in/stats/testing/latest");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "efd6234b-3e85-42f4-6e52-67c80c45f567");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            PocoCourse1 items = JsonConvert.DeserializeObject<PocoCourse1>(response.Content);
            return items.data.totalIndividualsTested;
        }

        public class PocoCourse
        {
            public bool Success { get; set; }
            public data data { get; set; }
            public DateTime lastRefreshed { get; set; }
        }

        public class PocoCourse1
        {
            public bool Success { get; set; }
            public data1 data { get; set; }
            public DateTime lastRefreshed { get; set; }
        }

        public class data1
        {
            public string day { get; set; }
            public string totalSamplesTested { get; set; }
            public string totalIndividualsTested { get; set; }
            public string totalPositiveCases { get; set; }
            public string source { get; set; }
        }

        public class data
        {
            public summary summary { get; set; }
            public List<regional> regional { get; set; }
        }

        public class regional
        {
            public string loc { get; set; }
            public string confirmedCasesIndian { get; set; }
            public int discharged { get; set; }
            public int deaths { get; set; }
            public string confirmedCasesForeign { get; set; }
            public int totalConfirmed { get; set; }
        }

        public class summary 
        {
            public int total { get; set; }
            public string confirmedCasesIndian { get; set; }
            public string confirmedCasesForeign { get; set; }
            public float discharged { get; set; }
            public float deaths { get; set; }
            public string confirmedButLocationUnidentified { get; set; }
        }
    }
}