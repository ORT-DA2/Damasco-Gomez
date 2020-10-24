using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
namespace DataAccess.Context
{
    [ExcludeFromCodeCoverage]
    public class VidlyContext : DbContext
    {
        public DbSet<Booking> Bookings {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<CategoryTouristPoint> CategoriesTouristicPoints {get; set;}
        public DbSet<House> Houses {get; set;}
        public DbSet<Person> Persons {get; set;}
        public DbSet<Region> Regions {get; set;}
        public DbSet<SessionUser> Sessions {get; set;}
        public DbSet<State> States {get; set;}
        public DbSet<TouristPoint> TouristPoints {get; set;}

        public DbSet<Report> Reports {get; set;}

        public VidlyContext(){}
        public VidlyContext(DbContextOptions options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string directory = System.IO.Directory.GetCurrentDirectory();
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();
                var connectionString = configuration.GetConnectionString(@"UruguayNaturalDB");
                optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();

            }
        }
    }
}