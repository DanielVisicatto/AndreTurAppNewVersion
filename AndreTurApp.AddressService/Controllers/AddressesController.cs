using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.AddressService.Data;
using AndreTurApp.Models;
using AndreTurApp.Models.DTOs;
using AndreTurApp.Services;

namespace AndreTurApp.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AndreTurAppAddressServiceContext _context;
        private readonly PostOffice _postOfficeService;

        public AddressesController(AndreTurAppAddressServiceContext context, PostOffice postOfficeService)// injeção de dependencia
        {
            _context = context;
            _postOfficeService = postOfficeService;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var context = _context.Address.Include(c => c.City).AsQueryable();

            return await context.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            if (_context.Address == null)
            {
                return new Address();
            }
            var address = await _context.Address.Include(a => a.City).Where(c => c.Id == id).FirstOrDefaultAsync();

            if (address == null)
            {
                return new Address();
            }

            return address;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Address>> PutAddress(int id, AddressDTOPut requestDTO)
        {                   
            var postAddress = await _context.Address.FindAsync(id); //objeto vindo desde o banco

            postAddress.Id = requestDTO.Id;
            postAddress.Number = requestDTO.Number;
            postAddress.Complement = requestDTO.Complement;

            _context.Entry(postAddress).State = EntityState.Modified;

            try
            {               
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return new Address();
                }
                else
                {
                    throw;
                }
            }

            return postAddress;
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            if (_context.Address == null)
            {
                return Problem("Entity set 'AndreTurAppAddressServiceContext.Address'  is null.");
            }
            // Aqui precisamos chamar o serviço de consulta  de endereço ViaCEP
            var number = address.Number;
            var zip = address.ZipCode;
            var complement = address.Complement;

            AddressDTO addressDTO = _postOfficeService.GetAddress(address.ZipCode).Result;
            var completeAddress = new Address(addressDTO);

            //Tenho que trazer o endereço completo agora para a aplicação.
            completeAddress.Number = number;
            completeAddress.ZipCode = zip;
            completeAddress.Complement = complement;
            completeAddress.City.RegisterDate = DateTime.Now;

            _context.Address.Add(completeAddress);

            await _context.SaveChangesAsync();

            return  address;
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult< Address>> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();
            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool AddressExists(int id)
        {
            return (_context.Address?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
