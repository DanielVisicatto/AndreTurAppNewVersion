using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.Models;

namespace AndreTurAppNewVersion.Data
{
    public class AndreTurAppNewVersionContext : DbContext
    {
        public AndreTurAppNewVersionContext (DbContextOptions<AndreTurAppNewVersionContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurApp.Models.City> City { get; set; } = default!;

        public DbSet<AndreTurApp.Models.Address>? Address { get; set; }

        public DbSet<AndreTurApp.Models.Customer>? Customer { get; set; }

        public DbSet<AndreTurApp.Models.Hotel>? Hotel { get; set; }

        public DbSet<AndreTurApp.Models.Ticket>? Ticket { get; set; }

        public DbSet<AndreTurApp.Models.Package>? Package { get; set; }
    }
}
