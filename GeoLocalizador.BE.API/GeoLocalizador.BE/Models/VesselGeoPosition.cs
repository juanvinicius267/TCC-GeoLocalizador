using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models
{
    public class VesselGeoPosition
    {
        [Key]
        public int IdPosition { get; set; }
        public int IdVesselInfo { get; set; }
        public VesselInfo VesselInfo { get; set; }
        public DateTime? LastPositionReceived { get; set; }
        public string LocationArea { get; set; }
        public string Current_Port { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Status { get; set; }
        public string SpeedCourse { get; set; }
        public string AISSource { get; set; }
        public DateTime LogDate { get; set; }

    }
}
