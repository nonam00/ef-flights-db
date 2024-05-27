using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FlightsDb.Models;

namespace FlightsDb.EntityTypeConfigurations 
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.HasKey(a => a.Id);
            
            builder.Property(a => a.Title)
                   .HasMaxLength(250);

            builder.Property(a => a.Country)
                   .HasMaxLength(250);

            builder.Property(a => a.City)
                   .HasMaxLength(250);

            builder.ToTable("Destinations");
        }
    }
}
