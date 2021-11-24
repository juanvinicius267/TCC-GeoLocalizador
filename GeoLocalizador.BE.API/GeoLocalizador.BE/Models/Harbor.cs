using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models
{
    public class Harbor
    {
        [Key]
        public int IdHarbor { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Country { get; set; }
        public string UrlPhoto { get; set; }
        public int? IdMarineTraffic { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime LastChange { get; set; }
    }
}
