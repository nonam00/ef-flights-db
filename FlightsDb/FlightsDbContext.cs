using FlightsDb.EntityTypeConfigurations;
using FlightsDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightsDb
{
    public class FlightsDbContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Trip> Trips { get; set; } 
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PassengerConfiguration());
            builder.ApplyConfiguration(new AirportConfiguration());
            builder.ApplyConfiguration(new TripConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
