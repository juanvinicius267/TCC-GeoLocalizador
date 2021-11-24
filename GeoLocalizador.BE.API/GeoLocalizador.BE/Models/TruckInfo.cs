using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models
{
    public class TruckInfo
    {
        [Key]
        public int IdTruck { get; set; }
        public string LicensePlate { get; set; }
        public string Carrier { get; set; }
        public int VolumeCapacity { get; set; }
        public int WeightCapacity { get; set; }
        public string Model { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
