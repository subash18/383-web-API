using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace MobileApplication.Services
{
    public class SingletonClient
    {
        public static IRestClient Client = new RestClient(Globals.Global.baseUrl);
        
        private SingletonClient() { }

        public static IRestClient GetClient()
        {
            if (Client == null)
            {
                Client = new RestClient(Globals.Global.baseUrl);

            }
            return Client;
        }
    }
}
