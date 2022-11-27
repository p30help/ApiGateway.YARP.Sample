using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/order/[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetOrders")]
        public IEnumerable<OrderModel> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new OrderModel
            {
                Date = DateTime.Now.AddDays(index),
                Code = Random.Shared.Next(-20, 55),
                ProductName = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}