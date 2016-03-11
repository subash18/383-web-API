using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIPhase_2.Models;
using WebAPIPhase_2.Models.DTOs;
using WebAPIPhase_2.Services;

namespace WebAPIPhase_2.Controllers
{
    public class ManufacturersController : BaseAPIController
    {
        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();
        private IManufacturerRepository repo = new MaufacturerRepository();

        // GET: api/Manufacturers
        public HttpResponseMessage GetManufacturer()
        {
            List<ManufacturerDTO> ListOfManufacturers = new List<ManufacturerDTO>();

            foreach (var item in repo.GetManufacturers())
            {
                ListOfManufacturers.Add(TheDTOFactory.Create(item));

            }
            return Request.CreateResponse(HttpStatusCode.OK, ListOfManufacturers);
        }

        // GET: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public HttpResponseMessage GetManufacturer(int id)
        {
            var manufacturer = repo.GetManufacturer(id);
           
            if (manufacturer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "the category is not found");
            }
            var factoryManufacturer = TheDTOFactory.Create(manufacturer);

            return Request.CreateResponse(HttpStatusCode.OK, factoryManufacturer);
        }


        [ResponseType(typeof(Manufacturer))]
        public HttpResponseMessage GetManufacturer(string name)
        {
            var manufacturer = repo.GetManufacturer(name);

            if (manufacturer == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "the category is not found");
            }
            var factoryManufacturer = TheDTOFactory.Create(manufacturer);

            return Request.CreateResponse(HttpStatusCode.OK, factoryManufacturer);
        }
        // PUT: api/Manufacturers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutManufacturer(int id, Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturer.ManufacturerId)
            {
                return BadRequest();
            }

            db.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Manufacturers
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult PostManufacturer(Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Manufacturer.Add(manufacturer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = manufacturer.ManufacturerId }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [ResponseType(typeof(Manufacturer))]
        public IHttpActionResult DeleteManufacturer(int id)
        {
            Manufacturer manufacturer = db.Manufacturer.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            db.Manufacturer.Remove(manufacturer);
            db.SaveChanges();

            return Ok(manufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ManufacturerExists(int id)
        {
            return db.Manufacturer.Count(e => e.ManufacturerId == id) > 0;
        }
    }
}