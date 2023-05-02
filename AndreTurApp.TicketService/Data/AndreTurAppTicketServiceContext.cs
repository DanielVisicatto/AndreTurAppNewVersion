using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.Models;

namespace AndreTurApp.TicketService.Data
{
    public class AndreTurAppTicketServiceContext : DbContext
    {
        public AndreTurAppTicketServiceContext (DbContextOptions<AndreTurAppTicketServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurApp.Models.Ticket> Ticket { get; set; } = default!;
    }
}
