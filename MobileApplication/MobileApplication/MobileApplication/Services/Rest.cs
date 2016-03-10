using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace MobileApplication.Services
{
    public class Rest {

        public IRestRequest request { get; set; }

        
        public Rest(string apiUrl, Method httpVerb)
        {
            this.request = new RestRequest(apiUrl, httpVerb);
        }

        
    }
}
