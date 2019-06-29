using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTrackSharp.Models
{
    public class AircraftModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual Aircraft Aircraft { get; set; }
    }
}
