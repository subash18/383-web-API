using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIPhase_2.Models;

namespace WebAPIPhase_2.Services
{
  public  interface IProductRepository
    {

        IEnumerable<Product> GetAllProducts();

        Product getProductById(int id);
        void putProduct(int id, Product product);
        void createProduct(Product product);
    }
}
