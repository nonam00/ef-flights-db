using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FlightsDb.Models;

namespace FlightsDb.EntityTypeConfigurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(p => p.Id);
            
            builder.HasAlternateKey(p => p.PassportNumber);
        }
    }
}
