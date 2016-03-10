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

        public  User roleUser = new Models.User();
        private DTOFactory _factory;
        private IProductRepository _repo;
        private IAPIKeyRepository _repo1;


        public WebAPIPhase_2Context db = new WebAPIPhase_2Context();

        public BaseAPIController()
        {
            _repo = new ProductRepository();
        }
        public BaseAPIController(IAPIKeyRepository _repo1)
        {
            this._repo1 = _repo1;
        }

      public BaseAPIController(IProductRepository repo)
        {
           
            _repo = repo;
            
           
            //string h1 = Request.Headers.Where(s => s.Key == "xcmps383authenticationid").FirstOrDefault().Value.ToString();
            //string h2 = Request.Headers.Where(s => s.Key == "xcmps383authenticationkey").FirstOrDefault().Value.ToString();

            //storeUser = db.Users.Where(s => s.Email == h1 && s.ApiKey == h2).FirstOrDefault();
        }

       /* protected bool IsAdmin()
        {
            return Enum.GetName(typeof(Role), roleUser.Role) == ("Admin");
        }

        protected bool IsCustomer()
        {
            return Enum.GetName(typeof(Role), roleUser.Role) == ("Customer");
        }*/
        protected IAPIKeyRepository TheAPIRepository
        {
            get
            {
                return _repo1;

            }
        }
        protected IProductRepository TheRepository
        {
          get
            {
                return _repo;

            }
        }

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
