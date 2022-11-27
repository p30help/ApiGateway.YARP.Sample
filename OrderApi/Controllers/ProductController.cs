using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/order/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetProducts")]
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