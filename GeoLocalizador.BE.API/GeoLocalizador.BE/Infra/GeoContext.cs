using GeoLocalizador.BE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Infra
{
    public class GeoContext : DbContext
    {
        public GeoContext(DbContextOptions<GeoContext> options)
            : base(options)
        {
        }

        public DbSet<Harbor> Harbors { get; set; }
        public DbSet<VesselGeoPosition> VesselGeoPositions { get; set; }
        public DbSet<VesselInfo> VesselInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GeoPosition> GeoPositions { get; set; }
        public DbSet<TruckGeoPosition> TruckGeoPositions { get; set; }
        public DbSet<TruckInfo> TruckInfos { get; set; }
        public DbSet<TruckTravel> TruckTravels { get; set; }
        public DbSet<VesselTravel> VesselTravels { get; set; }

    }
}
