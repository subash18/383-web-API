using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Security;
using WebAPIPhase_2.Models;
using WebAPIPhase_2.Services;

namespace WebAPIPhase_2.Controllers
{
    public class APIKeyController : BaseAPIController
    {
        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();
        private IAPIKeyRepository repo = new APIKeyRepository();

        [AllowAnonymous]
        public HttpResponseMessage GetApiKey(string email, string password)
        {
            
            var getUser = repo.getApiKey(email, password);
            var user = db.Users.First(x => x.Email == email);
            if (user != null)
            {
                if (Crypto.VerifyHashedPassword(user.Password, password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                }
            }

            if (getUser == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Invalid Email or Password");
            }
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (getUser.ApiKey == null)
            {
                try
                {
                    getUser.ApiKey = GetApiKey();
                    db.Entry(getUser).State = EntityState.Modified;
                    //db.Entry(getUser).CurrentValues.SetValues(getUser);
                    db.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to save API key to database");
                }

            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("xcmps383authenticationid", getUser.UserId.ToString());
            response.Headers.Add("xcmps383authenticationkey", getUser.ApiKey);



             return Request.CreateResponse(HttpStatusCode.OK, TheDTOFactory.Create(getUser.ApiKey, getUser.UserId));
            
          
          //  return response;
        }
        
        private string GetApiKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[16];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}


