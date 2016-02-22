using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Authentication
{
    public class Validation : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (!ValidateByApiKey(request))
            {

                var response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                var taskComplete = new TaskCompletionSource<HttpResponseMessage>();
                taskComplete.SetResult(response);
                return taskComplete.Task;
            }

            return base.SendAsync(request, cancellationToken);


        }

        private bool ValidateByApiKey(HttpRequestMessage request)
        {
            WebAPIPhase_2Context db = new WebAPIPhase_2Context();

            var headers = request.Headers;

            if (headers.Contains("xcmps383authenticationkey") && headers.Contains("xcmps383authenticationid"))
            {
                var apiKey = (headers.Where(m => m.Key == "xcmps383authenticationkey").First().Value.First());
                var userID = Convert.ToInt32(headers.Where(m => m.Key == "xcmps383authenticationid").First().Value.First());
                var user = db.Users.FirstOrDefault(m => m.UserId == userID);
                return (user != null && user.ApiKey == apiKey);
            }
            return false;
        }

    }
}
