using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models
{
    public class TruckTravel
    {
        [Key]
        public int IdTravel { get; set; }
        public int IdOrigin { get; set; }
        public GeoPosition Origin { get; set; }
        public int IdDestination { get; set; }
        public GeoPosition Destination { get; set; }
        public int IdTruck { get; set; }
        public TruckInfo Truck { get; set; }
        public string Cargo { get; set; }
        public string Status { get; set; }
        public DateTime LogDate { get; set; }
    }
}
