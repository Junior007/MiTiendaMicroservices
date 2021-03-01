using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ordering.application.interfaces;
using ordering.application.models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ordering.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrdersService ordersService, ILogger<OrderController> logger)
        {
            _ordersService = ordersService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET api/<OrderController>/5
        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Order>>> Get(string userName)
        {

            return Ok( await _ordersService.GetOrdersByUser(userName));
        }

    }
}
