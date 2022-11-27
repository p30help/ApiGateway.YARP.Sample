using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetCustomers")]
        public IEnumerable<CustomerModel> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new CustomerModel
            {
                RecordDate = DateTime.Now.AddDays(index),
                UserId = Random.Shared.Next(-20, 55),
                UserName = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}