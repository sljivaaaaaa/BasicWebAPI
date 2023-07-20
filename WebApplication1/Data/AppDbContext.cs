using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Companies
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, CompanyName = "Company A" },
                new Company { CompanyId = 2, CompanyName = "Company B" },
                new Company { CompanyId = 3, CompanyName = "Company C" }
            );

            // Seed data for Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "Country X" },
                new Country { CountryId = 2, CountryName = "Country Y" }
            );

            // Seed data for Contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, ContactName = "Contact 1", CompanyId = 1, CountryID = 1 },
                new Contact { ContactId = 2, ContactName = "Contact 2", CompanyId = 2, CountryID = 2 },
                new Contact { ContactId = 3, ContactName = "Contact 3", CompanyId = 3, CountryID = 1 }
            );
        }
    }
}
