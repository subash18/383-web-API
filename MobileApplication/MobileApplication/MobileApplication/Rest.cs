using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace MobileApplication
{
    public class Rest {

        public IRestClient client { get; set; }
        public IRestRequest request { get; set; }

        
        public Rest(string baseUrl, string apiUrl, Method httpVerb)
        {
            this.client = new RestClient(baseUrl);
            this.request = new RestRequest(apiUrl, httpVerb);
        }

        
    }
}
