using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("city")]
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;
        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult GetCities(){
            return Ok(_repository.GetCities());
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] City city){
            return Created("city", _repository.AddCity(city));
        }

        [HttpPut]
        public IActionResult PutCity([FromBody] City city){
            return Ok(_repository.UpdateCity(city));
        }
    }
}