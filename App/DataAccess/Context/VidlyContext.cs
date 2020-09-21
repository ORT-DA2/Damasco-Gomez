using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess.Context
{
    public class VidlyContext : DbContext
    {
        public DbSet<TouristPoint> TouristPoints {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<House> Houses {get; set;}
        public DbSet<Booking> Bookings {get; set;}
        public DbSet<Person> Persons {get; set;}
        public DbSet<Region> Regions {get; set;}

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
                var connectionString = configuration.GetConnectionString(@"VidlyDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}