using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Authentication
{
   public class ValidationAPI : DelegatingHandler
    { 
   private int? id = null;
    private string key = null;

    protected async override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {

        if (id != null)
        {
            using (WebAPIPhase_2Context db = new WebAPIPhase_2Context())
            {
                var user = db.Users.Find(id);
                if (user.ApiKey == key)
                {
                    IList<Claim> claim = new List<Claim>
                    {
                        new Claim (ClaimTypes.Name, user.Email),
                        new Claim (ClaimTypes.Role, user.Role.ToString())
                    };
                    var identity = new ClaimsIdentity(claim, "APIKey");
                    var principal = new ClaimsPrincipal(identity);

                    Thread.CurrentPrincipal = principal;
                }
            }
        }

        var response = await base.SendAsync(request, cancellationToken);

        var headers = response.Headers;

        if (headers.Contains("xcmps383authenticationid") && headers.Contains("xcmps383authenticationid"))
        {
            id = Int32.Parse(response.Headers.GetValues("xcmps383authenticationid").FirstOrDefault());
            key = response.Headers.GetValues("xcmps383authenticationkey").FirstOrDefault();
        }

        return response;
    }

}
}