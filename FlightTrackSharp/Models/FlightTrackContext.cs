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
        
    }
}
