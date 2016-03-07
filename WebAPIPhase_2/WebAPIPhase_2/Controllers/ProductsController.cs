using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIPhase_2.Authentication;
using WebAPIPhase_2.Models;
using WebAPIPhase_2.Models.DTOs;
using WebAPIPhase_2.Services;

namespace WebAPIPhase_2.Controllers
{
    public class ProductsController : BaseAPIController
    {

        public ProductsController(IProductRepository repo) : base(repo)
        {

        }
        // private Product_repository _repo = new Product_repository();
     
       private WebAPIPhase_2Context db = new WebAPIPhase_2Context();

        // GET: api/Products

       // [RoleAuthentication("Admin")]
        public HttpResponseMessage GetProducts()


        {
          //  if (IsAuthorized(Request, new List<Role> { Role.Admin }))
            //{
                List<ProductDTO> ProductList = new List<ProductDTO>();

                foreach (var item in TheRepository.GetAllProducts())
                {
                    ProductList.Add(TheDTOFactory.Create(item));
                }

                return Request.CreateResponse(HttpStatusCode.OK, ProductList);


           // }
           // return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public HttpResponseMessage GetProduct(int id)
        {
            
            // find the product from the repo + database 
            Product productFound = TheRepository.getProductById(id);

            if (productFound == null)
            {

                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found");

            }

            ProductDTO productfactoried = TheDTOFactory.Create(productFound);
            return Request.CreateResponse(HttpStatusCode.OK, productfactoried);
          
        }
        [HttpPost]
        [AllowAnonymous]
        [System.Web.Http.ActionName("UpdateProducts")]
        public HttpResponseMessage UpdateProducts([FromUri]string email, List<Product> products )
        {
            ProductPurchased purchased = new ProductPurchased();
            Product product;
            decimal count = 0;
            if (products == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            Sale sale = new Sale();
            sale.SaleDate = DateTime.Today;
            sale.Email = email;
            db.Sales.Add(sale);
            foreach (var items in products)
            {
                sale.TotalAmount += items.InventoryCount * items.Price;
            }
            foreach (var item in products)
            {
                product = db.Products.Find(item.ProductId);
                product.InventoryCount = product.InventoryCount - item.InventoryCount;

                purchased.ProductId = item.ProductId;
                purchased.Quantity = item.InventoryCount;
                purchased.SaleId = sale.SaleId;
                db.ProductPurchased.Add(purchased);

                //db.Entry(product).State = EntityState.Modified;
                //db.Entry(purchased).State = EntityState.Modified;
                //db.Entry(sale).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(item.ProductId))
                    {
                        return Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //// PUT: api/Products/5
        //[ResponseType(typeof(void))]
        //public HttpResponseMessage PutProduct(int id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
        //    }

        //    if (id != product.ProductId)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }


        //    TheRepository.putProduct(id, product);

        //    //db.Entry(product).State = EntityState.Modified;

        //    //try
        //    //{
        //    //    db.SaveChanges();
        //    //}
        //    //catch (DbUpdateConcurrencyException)
        //    //{
        //    //    if (!ProductExists(id))
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    else
        //    //    {
        //    //        throw;
        //    //    }
        //    //}

        //    //return StatusCode(HttpStatusCode.NoContent);

        //    ProductDTO productfactoried = TheDTOFactory.Create(product);
        //    return Request.CreateResponse(HttpStatusCode.OK, productfactoried);
        //}



        [HttpPut]
      [AllowAnonymous]
        [System.Web.Http.ActionName("PutProduct")]
        public HttpResponseMessage PutProduct( [FromBody]Product product)
        {

            if (ModelState.IsValid)
            {
                TheRepository.createProduct(product);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, product);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.ProductId }));
               

            ProductDTO productfactoried = TheDTOFactory.Create(product);

            return Request.CreateResponse(HttpStatusCode.OK, productfactoried);

         }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
}

        

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}