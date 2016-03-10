using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIPhase_2.Models;
using WebAPIPhase_2.Models.DTOs;
using WebAPIPhase_2.Services;

namespace WebAPIPhase_2.Controllers
{
 
    public class CategoriesController : BaseAPIController
    {
        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();
        private ICategoryRepository repo = new CategoryRepository();

        // GET: api/Categories
        public HttpResponseMessage GetCategory()
        {
            List<CategoryDTO> ListOfCategory = new List<CategoryDTO>();

            foreach (var item in repo.GetCategory())
            {
                ListOfCategory.Add(TheDTOFactory.Create(item));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ListOfCategory);
          
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public HttpResponseMessage GetCategory(int id)
        {

         var category = repo.GetCategory(id);
          
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category not found");
            }
            var factoryCategory = TheDTOFactory.Create(category);
          return Request.CreateResponse(HttpStatusCode.OK, factoryCategory);
        }

        [ResponseType(typeof(Category))]
        public HttpResponseMessage GetCategory(string name)
        {

            var category = repo.GetCategory(name);

            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category not found");
            }

            var factoryCategory = TheDTOFactory.Create(category);

            return Request.CreateResponse(HttpStatusCode.OK, factoryCategory);
        }



        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Category.Add(category);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Category.Remove(category);
            db.SaveChanges();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Category.Count(e => e.CategoryId == id) > 0;
        }
    }
}