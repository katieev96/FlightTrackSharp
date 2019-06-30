using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTrackSharp.Models
{
    public class FlightTrackContext : DbContext
    {
        public FlightTrackContext(DbContextOptions<FlightTrackContext> options): base(options)
        {

        }
        
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<AircraftManufacturer> AircraftManufacturers { get; set; }
        public DbSet<AircraftModel> AircraftModels { get; set; }
        public DbSet<FlightInformation> FlightInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aircraft>().ToTable("Aircraft");
            modelBuilder.Entity<AircraftManufacturer>().ToTable("AircraftManufacturer");
            modelBuilder.Entity<AircraftModel>().ToTable("AircraftModel");
            modelBuilder.Entity<FlightInformation>().ToTable("FlightInformation");
        }
    }
}
