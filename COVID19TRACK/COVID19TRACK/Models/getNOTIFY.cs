using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COVID19TRACK.Models
{
    public class getNOTIFY 
    {
        public List<notification> getData(out DateTime lastRefreshed)
        {
            var client = new RestClient("https://api.rootnet.in/covid19-in/notifications");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "efd6234b-3e85-42f4-6e52-67c80c45f567");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            PocoCourse items = JsonConvert.DeserializeObject<PocoCourse>(response.Content);
            lastRefreshed = items.lastRefreshed;
            return items.data.notifications.Where(x => x.title.Contains(".2020")).ToList();
        }

        public class PocoCourse
        {
            public bool Success { get; set; }
            public data data { get; set; }
            public DateTime lastRefreshed { get; set; }
        }

        public class data
        {
            public List<notification> notifications { get; set; }
        }

        public class notification
        {
            public string title { get; set; }
            public string link { get; set; }
            public string date {
                get { return title.Substring(0, 10); }
                set { date = value; }
            }
        }
    }
}