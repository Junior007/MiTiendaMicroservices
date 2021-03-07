using basket.application.interfaces;
using basket.application.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace basket.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketsService;

        public BasketController(IBasketService basketsService, ILogger<BasketController> logger)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _basketsService = basketsService ?? throw new ArgumentNullException(nameof(basketsService));
        }


        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> Get(string userName)
        {
            BasketCart basket = await _basketsService.Get(userName);
            return Ok(basket ?? new BasketCart(userName));
        }
        /*
        [HttpPut("{userName}")]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BasketCart>> Put([FromBody] BasketCart basketCar, string userName)
        {
            if (userName == basketCar.UserName)
            {
                return Ok(await _basketsService.Update(basketCar));
            }
            else
            {
                return BadRequest("Diferent id");
            }
        }
        */

        [HttpPut("AddItem/{userName}")]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BasketCart>> AddItem(string userName, [FromBody] BasketCartItem basketCar)
        {
            //if (userName == basketCar.UserName)
            {
                return Ok(await _basketsService.AddItem(userName, basketCar ));
            }
            /*else
            {
                return BadRequest("Diferent id");
            }*/
        }

        [HttpPut("RemoveItem/{userName}")]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<BasketCart>> RemoveItem(string userName, [FromBody] BasketCartItem basketCar)
        {
            //if (userName == basketCar.UserName)
            {
                return Ok(await _basketsService.RemoveItem(userName, basketCar));
            }
            /*else
            {
                return BadRequest("Diferent id");
            }*/
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string userName)
        {
            return Ok(await _basketsService.Delete(userName));
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> Checkout([FromBody] BasketCartCheckout basketCheckout)
        {

            if (await _basketsService.Checkout(basketCheckout))
            {
                return Accepted();
            }
            else
            {
                return BadRequest("");
            }

        }
    }
}
