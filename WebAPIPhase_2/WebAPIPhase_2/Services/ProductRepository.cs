
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
   public class ProductRepository : IProductRepository
    {
        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();


        public IQueryable<Product> GetAllProducts()
        {
            return db.Products;
        }

        public Product getProductById(int id)
        {
            Product productInDatabase = db.Products.Find(id);

            return productInDatabase;
        }

        public void putProduct(int id, Product product)
        {
            Product updatedProduct = getProductById(id);
            updatedProduct.Name = product.Name;
            updatedProduct.Price = product.Price;
            updatedProduct.InventoryCount = product.InventoryCount;
            updatedProduct.CreatedDate = product.CreatedDate;
            updatedProduct.LastModifiedDate = product.LastModifiedDate;
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.ManufacturerId = product.ManufacturerId;
            db.Entry(updatedProduct).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

        public void createProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();

           
        }

    }
}
