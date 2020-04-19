using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COVID19TRACK.Models
{
    public class getHelpline
    {
        public List<regional> getData(out string number, out string numbertollfree, out string email, out string facebook)
        {
            var client = new RestClient("https://api.rootnet.in/covid19-in/contacts");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "efd6234b-3e85-42f4-6e52-67c80c45f567");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);
            PocoCourse items = JsonConvert.DeserializeObject<PocoCourse>(response.Content);
            number = items.data.contacts.primary.number;
            numbertollfree = items.data.contacts.primary.numbertollfree;
            email = items.data.contacts.primary.email;
            facebook = items.data.contacts.primary.facebook;
            return items.data.contacts.regional.OrderBy(x => x.loc).ToList();
        }

        public class PocoCourse
        {
            public bool Success { get; set; }
            public data data { get; set; }
            public DateTime lastRefreshed { get; set; }
        }

        public class data
        {
            public contacts contacts { get; set; }
        }

        public class contacts
        {
            public primary primary { get; set; }
            public List<regional> regional { get; set; }
        }

        public class primary
        {
            public string number { get; set; }
            public string numbertollfree { get; set; }
            public string email { get; set; }
            public string twitter { get; set; }
            public string facebook { get; set; }
            public dynamic media { get; set; }
        }

        public class regional
        {
            public string loc { get; set; }
            public string number { get; set; }
        }
    }
}