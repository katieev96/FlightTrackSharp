using FlightTrackSharp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTrackSharp.Data
{
    public class DbInitializer
    {
        public static void Initialize(FlightTrackContext context)
        {
            context.Database.EnsureCreated();
            Clean(context);
            SeedAircraftModels(context);
            SeedAircraftManufacturers(context);
            SeedAircrafts(context, context.AircraftManufacturers.ToArray(), context.AircraftModels.ToArray());
        }

        public static void SeedAircraftModels(FlightTrackContext context)
        {
            var crafts = new AircraftModel[]
            {
                new AircraftModel
                {
                    Id = Guid.NewGuid(),
                    Name = "PA44-180"
                },
                new AircraftModel
                {
                    Id = Guid.NewGuid(),
                    Name = "PA28R-201"
                },
                new AircraftModel
                {
                    Id = Guid.NewGuid(),
                    Name = "PA28-161"
                }
            };
            foreach (AircraftModel m in crafts)
            {
                context.AircraftModels.Add(m);
            }
            context.SaveChanges();
        }

        public static void SeedAircraftManufacturers(FlightTrackContext context)
        {
            var man = new AircraftManufacturer[]
            {
                new AircraftManufacturer
                {
                    Id= Guid.NewGuid(),
                    Name = "Boeing"
                },
                new AircraftManufacturer
                {
                    Id= Guid.NewGuid(),
                    Name = "Piper"
                }
            };
            foreach(AircraftManufacturer m in man)
            {
                context.AircraftManufacturers.Add(m);
            }
            context.SaveChanges();
        }

        public static void SeedAircrafts(FlightTrackContext context, AircraftManufacturer[] man, AircraftModel[] mod)
        {
            var a = new Aircraft[]
            {
                new Aircraft
                {
                    Id= Guid.NewGuid(),
                    AircraftManufacturer = man[0],
                    AircraftModel = mod[0],
                    Country = "US",
                    EngineType = "1",
                    NumEngines = 2,
                    TailNumber = "N298MG"
                }
            };
            foreach (Aircraft aircraft in a)
            {
                context.Aircrafts.Add(aircraft);
            }
            context.SaveChanges();
        }

        public static void Clean(FlightTrackContext context)
        {
            context.Aircrafts.RemoveRange(context.Aircrafts);
            context.AircraftModels.RemoveRange(context.AircraftModels);
            context.AircraftManufacturers.RemoveRange(context.AircraftManufacturers);
            context.SaveChanges();
        }
    }
}
