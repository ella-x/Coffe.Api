using Microsoft.AspNetCore.Mvc;
using Coffe.Api.Repositories;
using Coffe.Api.Models;

namespace Coffe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        public CoffeeController(CofeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }
        [HttpGet]
        public List<CoffeeRecord> Get()
        {
            var records = _coffeeRepository.Get().OrderByDescending(x => x.DateCreated).ToList();
            return records;
        }

        [HttpGet("{id}")]
        public CoffeeRecord GetById(int id)
        {
            var record = _coffeeRepository.GetById(id);
            return record;
        }
        
         private readonly ILogger<CoffeeController> _logger;

         public CoffeeController(ILogger<CoffeeController> logger)
         {
             _logger = logger;
         }

    }
}