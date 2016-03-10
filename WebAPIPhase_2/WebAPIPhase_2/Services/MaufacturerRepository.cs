using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
    public class MaufacturerRepository :IManufacturerRepository
    {

        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();
        public IEnumerable<Manufacturer> GetManufacturers() {

            return db.Manufacturer;


        }

      public  Manufacturer GetManufacturer(int id) {
            var manufacturer = db.Manufacturer.Where(m => m.ManufacturerId == id).FirstOrDefault();
            return manufacturer;

        }
      public  Manufacturer GetManufacturer(string name) {
            var manufacturer = db.Manufacturer.Where(m => m.ManfacturerName == name).FirstOrDefault();
            return manufacturer;
        }
    }
}