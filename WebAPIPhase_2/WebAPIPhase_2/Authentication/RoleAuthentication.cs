using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPIPhase_2.Controllers;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Authentication
{

    public class RoleAuthentication : AuthorizeAttribute
    {
        private List<string> authorizedRoles;
        private BaseAPIController Controller;
        private User user;

        public RoleAuthentication(string roles)

        {
        authorizedRoles = new List<string>();
        if (roles != null)
            {
        roles.Trim(' ');
        authorizedRoles.AddRange(roles.Split(','));
    }
    if (Roles != null)
    {
        Roles.Trim(' ');
        authorizedRoles.AddRange(Roles.Split(','));
    }
}

/*public override void OnAuthorization(HttpActionContext actionContext)
{
    Controller = (BaseAPIController)actionContext.ControllerContext.Controller;
    user = Controller.roleUser;

    var userRoles = Enum.GetName(typeof(Role), user.Role);

    if (userRoles.Contains("Customer"))
    {
        return;
    }

    int userId = user.UserId;

    foreach (var role in authorizedRoles)
    {
        if (userRoles.Contains(role))
        {
            return;
        }
    }

    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
        "Higher Authorization Level Required!");
    return;
}*/
    }
}