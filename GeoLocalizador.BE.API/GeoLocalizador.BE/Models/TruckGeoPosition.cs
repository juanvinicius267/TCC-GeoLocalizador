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
        public string Course { get; set; }
        public string Speed { get; set; }
        public string Altitude { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string RunStatus { get; set; }
        public string GnssSat { get; set; }
        public string GlonasSat { get; set; }
        public string FixMode { get; set; }
        public DateTime LogDate { get; set; }
    }
}
