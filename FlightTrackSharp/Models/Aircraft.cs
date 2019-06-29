using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTrackSharp.Models
{
    public class Aircraft
    {
        public Guid Id { get; set; }
        public int NumEngines { get; set; }
        public string EngineType { get; set; }
        public string TailNumber { get; set; }
        public string Country { get; set; }

        public virtual AircraftModel AircraftModel { get; set; }
        public virtual AircraftManufacturer AircraftManufacturer { get; set; }
    }
}
