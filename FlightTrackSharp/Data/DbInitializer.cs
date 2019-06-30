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
            SeedFlightInfo(context, context.Aircrafts.ToArray());
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

        public static void SeedFlightInfo(FlightTrackContext context, Aircraft[] craft)
        {
            var info = new FlightInformation[]
            {
                new FlightInformation
                {
                    Id= Guid.NewGuid(),
                    Aircraft = craft[0],
                    Approaches = 0,
                    ApproachesHold = false,
                    CFI = 0,
                    Comments = "This is a sample comment",
                    CrossCountry = 0,
                    DateOfFlight = DateTime.Today,
                    Dual = 1,
                    FullStopDay = 0,
                    FullStopNight = 0,
                    GroundSim = 0,
                    IMC = 0,
                    Night = 1.5,
                    PIC = 0,
                    Route = "ATL to MSY",
                    SIC = 0,
                    SimulatedInstrument = 0,
                    Solo = 0,
                    TotalLandings = 12,
                    TotalTime = 2.5
                }
            };
            foreach (FlightInformation f in info)
            {
                context.FlightInformations.Add(f);
            }
            context.SaveChanges();
        }

        public static void Clean(FlightTrackContext context)
        {
            context.Aircrafts.RemoveRange(context.Aircrafts);
            context.AircraftModels.RemoveRange(context.AircraftModels);
            context.AircraftManufacturers.RemoveRange(context.AircraftManufacturers);
            context.FlightInformations.RemoveRange(context.FlightInformations);
            context.SaveChanges();
        }
    }
}
