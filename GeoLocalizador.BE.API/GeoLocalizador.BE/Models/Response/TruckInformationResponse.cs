using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Models.Response
{
    public class TruckInformationResponse : TruckTravel
    {
        public List<TruckGeoPosition> Positions { get; set; }
    }
}
