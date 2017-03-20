using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Prodo.API.Models;

namespace Prodo.API.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private static readonly ProductRepository ProductRepository = new ProductRepository();

        [Route("~/api/Categories/{categoryId:int}/Products")]
        [HttpGet]
        public IHttpActionResult Get(int categoryId)
        {
            return Ok(ProductRepository.GetProducts(categoryId));
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            return Ok(ProductRepository.GetProducts());
        }

        //[Route("{id:int?}")] optional param
        //[Route("{id:int=4}")] default param value
        [Route("{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = ProductRepository.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Product product)
        {
            if (product == null) throw new ArgumentNullException("product");

            var savedProduct = ProductRepository.SaveProduct(product);

            var response = Request.CreateResponse(HttpStatusCode.Created, savedProduct);

            var uri = Url.Link("DefaultApi", new { id = product.Id, controller = "Products" });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        [Route("{id:int}")]
        [HttpPut]
        public void Put(int id, [FromBody]Product product)
        {
            if (product == null) throw new ArgumentNullException("product");

            ProductRepository.UpdateProduct(id, product);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public void Delete(int id)
        {
            var product = ProductRepository.GetProduct(id);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ProductRepository.Delete(id);
        }
    }
}
