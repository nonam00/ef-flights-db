using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FlightsDb.Models;

namespace FlightsDb.EntityTypeConfigurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasAlternateKey(t => t.Number);

            builder.HasOne(t => t.Passenger)
                .WithMany()
                .HasForeignKey(t => t.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Trip)
               .WithMany()
               .HasForeignKey(t => t.TripId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
