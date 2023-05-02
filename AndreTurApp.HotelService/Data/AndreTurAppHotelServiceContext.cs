using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.Models;

namespace AndreTurApp.HotelService.Data
{
    public class AndreTurAppHotelServiceContext : DbContext
    {
        public AndreTurAppHotelServiceContext (DbContextOptions<AndreTurAppHotelServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurApp.Models.Hotel> Hotel { get; set; } = default!;
    }
}
