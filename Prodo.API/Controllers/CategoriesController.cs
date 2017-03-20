using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prodo.API.Models;

namespace Prodo.API.Controllers
{
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private static readonly ICategoryRepository CategoryRepository = new CategoryRepository();

        // GET: api/Categories
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(CategoryRepository.GetCategories());
        }

        // GET: api/Categories/2
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var product = CategoryRepository.GetCategory(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
