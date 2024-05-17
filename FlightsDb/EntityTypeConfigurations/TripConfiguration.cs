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

            builder.HasOne(t => t.DepartureAirport)
                .WithOne()
                .HasForeignKey<Trip>(t => t.DepartureAirportId)
                .HasConstraintName("FK_Trips_DepartureAirport")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.ArrivalAirport)
               .WithOne()
               .HasForeignKey<Trip>(t => t.ArrivalAirportId)
               .HasConstraintName("FK_Trips_ArrivalAirport")
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
