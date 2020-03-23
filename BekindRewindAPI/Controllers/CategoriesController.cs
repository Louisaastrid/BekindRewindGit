using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeKindRewind;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BekindRewindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepo;
        private readonly ILogger<CategoriesController> _logger;
        // GET api/values
        public  CategoriesController(ICatalogRepository catalogRepo, ILogger<CategoriesController> logger)
        {
            _catalogRepo = catalogRepo;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Category> Get() => _catalogRepo.Categories;
      

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
          
            
                var result = _catalogRepo.Categories.FirstOrDefault(categorie => categorie.CategoryId == id);
                if (result == null)
                {
                    return NotFound();

                }
                else
                {
                    return result;
                }
            
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
