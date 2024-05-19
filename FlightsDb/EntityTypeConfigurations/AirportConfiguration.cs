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

            builder.ToTable("Destination");
        }
    }
}
