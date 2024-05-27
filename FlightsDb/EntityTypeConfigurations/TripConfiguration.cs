using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FlightsDb.Models;

namespace FlightsDb.EntityTypeConfigurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.HasAlternateKey(t => t.Number);

            builder.HasOne(t => t.DepartureAirport)
                   .WithMany(a => a.DepartureTrips)
                   .HasForeignKey(t => t.DepartureAirportId)
                   .HasConstraintName("FK_Trips_DepartureAirport")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.ArrivalAirport)
                   .WithMany(a => a.ArrivalTrips)
                   .HasForeignKey(t => t.ArrivalAirportId)
                   .HasConstraintName("FK_Trips_ArrivalAirport")
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
