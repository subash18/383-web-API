using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
  public  interface IAPIKeyRepository
    {


        User getApiKey(string email, string password);
    }
}
