using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Table_Flight");
            builder.HasKey(f => f.FlightId);
            builder.HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(p => p.ToTable("Table_PassengerFlight"));
            builder.HasOne(f => f.Plane).WithMany(p => p.Flights).HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
