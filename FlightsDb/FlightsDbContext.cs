using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using FlightsDb.EntityTypeConfigurations;
using FlightsDb.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection.Emit;

namespace FlightsDb
{
    public class FlightsDbContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Trip> Trips { get; set; } 
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; } 
        
        public IQueryable<Airport> GetMaxPricesAirport() =>
            FromExpression(() => GetMaxPricesAirport());
        public IQueryable<Airport> GetMinPricesAirport() =>
            FromExpression(() => GetMinPricesAirport());

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();

            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
                   //.LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PassengerConfiguration());
            builder.ApplyConfiguration(new AirportConfiguration());
            builder.ApplyConfiguration(new TripConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new BeneficiaryConfiguration());

            builder.HasDbFunction(() => GetMaxPricesAirport());
            builder.HasDbFunction(() => GetMinPricesAirport());

            base.OnModelCreating(builder);
        }
    }
}
