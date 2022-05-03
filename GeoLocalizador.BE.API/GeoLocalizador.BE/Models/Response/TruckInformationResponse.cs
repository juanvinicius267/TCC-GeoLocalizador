using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models.Response
{
    public class TruckInformationResponse : TruckTravel
    {
        public List<TruckGeoPosition> Positions { get; set; }
        public string Course { get; set; }
        public string Speed { get; set; }
        public string Altitude { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string RunStatus { get; set; }
        public string GnssSat { get; set; }
        public string GlonasSat { get; set; }
        public string FixMode { get; set; }
    }
}
