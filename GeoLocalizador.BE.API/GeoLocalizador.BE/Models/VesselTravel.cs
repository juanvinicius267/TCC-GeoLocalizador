using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models
{
    public class VesselTravel
    {
        [Key]
        public int IdTravel { get; set; }
        public int IdOrigin { get; set; }
        public Harbor Origin { get; set; }
        public int IdDestination { get; set; }
        public Harbor Destination { get; set; }
        public int IdVessel { get; set; }
        public VesselInfo Vessel { get; set; }
        public string Cargo { get; set; }
        public string Status { get; set; }
        public DateTime LogDate { get; set; }
    }
}
