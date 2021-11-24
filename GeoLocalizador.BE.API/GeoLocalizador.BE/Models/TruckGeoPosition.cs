using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models
{
    public class TruckGeoPosition
    {
        [Key]
        public int IdPosition { get; set; }
        public int IdTruck { get; set; }
        public TruckInfo Truck { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Speed { get; set; }
        public string SignalQuality { get; set; }
        public int Satellites { get; set; }
        public int Altitude { get; set; }
        public char AltitudeUnits { get; set; }
        public float GeoSep { get; set; }
        public char GeoSepUnits { get; set; }
        public string AgeGpsData { get; set; }
        public string RefStationId { get; set; }
        public DateTime LogDate { get; set; }
    }
}
