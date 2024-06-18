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
            
            builder.Property(p => p.FirstName)
                   .HasMaxLength(100);

            builder.Property(p => p.LastName)
                   .HasMaxLength(100);

            builder.Ignore(p => p.Display);

            builder.UseTphMappingStrategy();

            builder.ToTable(t => 
            {
                t.HasCheckConstraint("CK_Passengers_BirthDate", "DATEDIFF(YEAR, BirthDate, GETDATE()) > 0");
            });
        }
    }
}
