using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace WebAPIPhase_2.Models.DTOs
{
  public  class DTOFactory
    {
        private WebAPIPhase_2Context db = new WebAPIPhase_2Context();

        private UrlHelper _urlHelper; 
      //  private UrlHelper urlbuilder { get; set; }


    
        public DTOFactory(HttpRequestMessage request)
        {
            _urlHelper = new UrlHelper(request);
        }

        public ProductDTO Create(Product product)
        {

        ProductDTO productDTO = new ProductDTO()
            {

                 Url = _urlHelper.Link("ProductRoute", new { id = product.ProductId }),
               // Url = string.Format("http://localhost:58198/api/Products/{0}", product.ProductId),
                Name = product.Name,
                CreatedDate = product.CreatedDate,
                LastModifiedDate = product.LastModifiedDate,
                Price = product.Price,
                InventoryCount = product.InventoryCount
            };

            return productDTO;

        }


        public ApiKeyDTO Create(string apikey, int id)
        {

            ApiKeyDTO ApiKeyDTO = new ApiKeyDTO()
            {
                ApiKey = apikey,
                UserId = id


            };
            return ApiKeyDTO;
        }





    }
}
