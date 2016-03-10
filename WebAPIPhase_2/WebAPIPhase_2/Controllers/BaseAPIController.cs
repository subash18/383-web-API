using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebAPIPhase_2.Models;
using WebAPIPhase_2.Models.DTOs;
using WebAPIPhase_2.Services;

namespace WebAPIPhase_2.Controllers
{
    public abstract class BaseAPIController : ApiController
    {
        //  public User storeUser;

      
        private DTOFactory _factory;
        public WebAPIPhase_2Context db = new WebAPIPhase_2Context();

        protected DTOFactory TheDTOFactory
        {

            get
            {
                if (_factory == null)
                {
                    _factory = new DTOFactory(this.Request);
                }
                return _factory;
            }

        }



       /* protected bool IsAuthorized(HttpRequestMessage request, List<Role> role)
        {

            int userID = Convert.ToInt32(request.Headers.Where(m => m.Key == "xcmps383authenticationid").FirstOrDefault().Value.FirstOrDefault());

            User user = db.Users.Find(userID);

            return (role.Contains(user.Role));

        }*/
    }
}
