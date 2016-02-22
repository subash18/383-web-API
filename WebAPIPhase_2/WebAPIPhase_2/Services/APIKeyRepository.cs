using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
    public class APIKeyRepository : IAPIKeyRepository
    {

        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();


        [AllowAnonymous]
        public User getApiKey(string email, string password)
        {
            
                var user = db.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();

                if (user != null)
                {

                    //if (Crypto.VerifyHashedPassword(user.Password, password))
                    //{
                        return user;
                   // }
                }
            
           
            else
            {
               user = null;
               return user;
            }
            
      }
    }
}

    

