using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> GetManufacturers();

        Manufacturer GetManufacturer(int id);
        Manufacturer GetManufacturer(string name);
    }
}