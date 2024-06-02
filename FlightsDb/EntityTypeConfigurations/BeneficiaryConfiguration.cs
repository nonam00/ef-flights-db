using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using FlightsDb.Models;

namespace FlightsDb.EntityTypeConfigurations
{
    public class BeneficiaryConfiguration : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> builder)
        {
            builder.Property(b => b.Sale)
                   .HasColumnType("decimal(8,2)")
                   .HasDefaultValueSql("0.1");
        }
    }
}
