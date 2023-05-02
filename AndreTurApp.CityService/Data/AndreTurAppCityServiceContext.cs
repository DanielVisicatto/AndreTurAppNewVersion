using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.Models;

namespace AndreTurApp.CityService.Data
{
    public class AndreTurAppCityServiceContext : DbContext
    {
        public AndreTurAppCityServiceContext (DbContextOptions<AndreTurAppCityServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurApp.Models.City> City { get; set; } = default!;
    }
}
