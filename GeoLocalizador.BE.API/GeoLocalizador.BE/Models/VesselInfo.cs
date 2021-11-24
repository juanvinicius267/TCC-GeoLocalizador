using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models
{
    public class VesselInfo
    {
        [Key]
        public int IdNavio { get; set; }
        public string IMO { get; set; }
        public string Name { get; set; }
        public string Vessel_Type_Generic { get; set; }
        public string Vessel_Type_Detailed { get; set; }
        public string Status { get; set; }
        public int MMSI { get; set; }
        public string Call_Sign { get; set; }
        public string Flag { get; set; }
        public string Gross_Tonnage { get; set; }
        public string LengthxBreadth { get; set; }
        public int Year_Built { get; set; }
        public string Home_Port { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime? LastChange { get; set; }
    }
}
