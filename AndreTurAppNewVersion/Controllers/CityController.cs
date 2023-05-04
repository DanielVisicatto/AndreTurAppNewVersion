using AndreTurApp.Models;
using AndreTurAppNewVersion.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AndreTurAppNewVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        // GET: api/<CityController>
        [HttpGet]
        public async Task<List<City>> Get()
        {
            return await _cityService.Get();
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<City> GetById(int id)
        {
            return await _cityService.GeById(id);
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<City> PostCity(City city)
        {
            return await _cityService.PostCity(city);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task <City> PutCity(int id, City city)
        {
            city.Id = id;
            return await _cityService.PutCity(city);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            _cityService.Delete(id);
        }
    }
}
