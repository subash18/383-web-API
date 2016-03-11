using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategory();

        Category GetCategory(int id);
        Category GetCategory(string name);
        }
    }
