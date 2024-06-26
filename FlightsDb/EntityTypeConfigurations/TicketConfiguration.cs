﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(t => t.Type)
                   .HasDefaultValue(TicketType.Economy);    
            
            builder.Property(t => t.Price)
                  .HasColumnType("decimal(8,2)");

            builder.HasOne(t => t.Passenger)
                   .WithMany(p => p.Tickets)
                   .HasForeignKey(t => t.PassengerId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.Trip)
                   .WithMany(trip => trip.Tickets)
                   .HasForeignKey(t => t.TripId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
