using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.Models;

namespace AndreTurApp.CustomerService.Data
{
    public class AndreTurAppCustomerServiceContext : DbContext
    {
        public AndreTurAppCustomerServiceContext (DbContextOptions<AndreTurAppCustomerServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurApp.Models.Customer> Customer { get; set; } = default!;
    }
}
