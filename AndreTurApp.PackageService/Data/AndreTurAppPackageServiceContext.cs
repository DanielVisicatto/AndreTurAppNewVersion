using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AndreTurApp.Models;

namespace AndreTurApp.PackageService.Data
{
    public class AndreTurAppPackageServiceContext : DbContext
    {
        public AndreTurAppPackageServiceContext (DbContextOptions<AndreTurAppPackageServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AndreTurApp.Models.Package> Package { get; set; } = default!;
    }
}
