using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plane> builder)
        {
            builder.HasKey(f => f.PlaneId);
            builder.ToTable("MyPlanes");//bech nbadel e2sm el table f database
            builder.Property(f => f.Capacity).HasColumnName("PlaneCapacity");// badalna 2esm el column
        }
    }
}
