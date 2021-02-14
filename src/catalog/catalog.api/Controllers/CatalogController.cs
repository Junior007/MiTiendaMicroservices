using catalog.api.settings;
using catalog.application.interfaces;
using catalog.application.models;
using catalog.data.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace catalog.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private readonly IProductsService _productsService;
        //private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductsService productsService)/*, ILogger<CatalogController> logger*/
        {
            _productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<CatalogController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get()
        {
            var products = await _productsService.Get();
            if (products == null || products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        // GET api/<CatalogController>/5
        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Get(string id)
        {
            try
            {
                var product = await _productsService.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                //_logger.LogError(string.Format("Error in {0}: stack trace{1}", ex.Message, ex.StackTrace));
                return BadRequest();
            }
        }
        //
        [HttpGet("[action]/{name}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetByName(string name)
        {
            IEnumerable<Product> products = await _productsService.GetProductByName(name);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        //
        [HttpGet("[action]/{category}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.NotFound)]

        public async Task<ActionResult> GetByCategory(string category)
        {
            IEnumerable<Product> products = await _productsService.GetProductByCategory(category);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        // POST api/<CatalogController>
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            await _productsService.Create(product);

            //return CreatedAtRoute("Get", new { id = product.Id }, product);

            return await _productsService.Get(product.Id);
        }

        // PUT api/<CatalogController>/5
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(string id, [FromBody] Product product)
        {
            if (id == product.Id)
            {
                return Ok(await _productsService.Update(product));
            }
            return BadRequest("Diferent id");

        }

        // DELETE api/<CatalogController>/5
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(string id, [FromBody] Product product)
        {
            if (id == product.Id)
            {
                return Ok(await _productsService.Delete(id));
            }
            return BadRequest("Diferent id");
        }
    }
}

