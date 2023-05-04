using AndreTurApp.Models;
using AndreTurAppNewVersion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AndreTurAppNewVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }


        // GET: api/<AddressController>
        [HttpGet]
        public async Task<List<Address>> GetAdress()
        {
            return await _addressService.GetAddress();
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public async Task<Address> GetAddressById(int id)
        {
            return await _addressService.GetAddressById(id);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult> PostAddress(Address address)
        {
            var response = (int)await _addressService.PostAddress(address);
            return StatusCode(response);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async  Task <ActionResult<Address>> UpdateAddress(int id, Address address)
        {
            address.Id = id;
            return _addressService.PutAddress(id, address).Result;            
        }

        //// DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _addressService.DeleteAddress(id);
        }
    }
}
