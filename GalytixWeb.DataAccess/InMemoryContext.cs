using GalytixWeb.DataAccess.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace GalytixWeb.DataAccess
{
    public class InMemoryContext : DbContext
    {
        private readonly DbSeeder _dbSeeder;

        public InMemoryContext(DbContextOptions<InMemoryContext> options, DbSeeder dbSeeder) : base(options) 
        {
            _dbSeeder = dbSeeder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GWPItem>().HasKey(x => new { x.Country, x.LineOfBusiness });
            _dbSeeder.Seed(modelBuilder);
            
        }

        public DbSet<GWPItem> GWPItems { get; set; }
    }
}
