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

            builder.HasOne(t => t.Passenger)
                .WithOne()
                .HasForeignKey<Ticket>(t => t.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Trip)
               .WithOne()
               .HasForeignKey<Ticket>(t => t.TripId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
