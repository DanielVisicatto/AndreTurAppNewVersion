using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.Models;

namespace AndreTurApp.AddressService.Data
{
    public class AndreTurAppAddressServiceContext : DbContext
    {
        public AndreTurAppAddressServiceContext (DbContextOptions<AndreTurAppAddressServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurApp.Models.Address> Address { get; set; } = default!;
    }
}
