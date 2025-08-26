//APPDB
using Creditevaluation.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Calculation> Calcualations { get; set; }
    }
}

