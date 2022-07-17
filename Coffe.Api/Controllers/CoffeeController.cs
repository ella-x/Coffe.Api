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
        public CoffeeController(ICoffeeRepository coffeeRepository)
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
        [HttpPost]
        public IActionResult InsertCategory(CoffeeRecord record)
        {
            try
            {
                _coffeeRepository.Add(record);
            }
            catch
            {
                return Ok(new { Success = false });
            }
            return Ok(new { Success = true });
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                _coffeeRepository.Delete(id);
            }
            catch
            {
                return Ok(new { Success = false });
            }
            return Ok(new { Success = true });
        }

        [HttpPut]
        public IActionResult UpdateRecord(CoffeeRecord record)
        {
            try
            {
                _coffeeRepository.Update(record);
            }
            catch
            {
                return Ok(new { Success = false });
            }
            return Ok(new { Success = true });
        }

    }
}