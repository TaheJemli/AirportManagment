using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            //modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //modelBuilder.Entity<Passanger>().Property(f => f.fullname.FirstName)
            //    .HasColumnName("PassangerName")
            //    .HasMaxLength(50)
            //    .IsRequired()
            //    .HasColumnType("varchar");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar").HaveMaxLength(50);
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<Double>().HavePrecision(2, 3);
        }


        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Passenger> Passangers { get; set; }
        public virtual DbSet<Traveller> Traveller { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        public virtual DbSet<Plane> Plane { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(localdb)\mssqllocaldb;initial catalog=TAHE;integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
