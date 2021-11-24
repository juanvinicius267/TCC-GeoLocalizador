using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Dao
{
    public class TruckGeoPositionDao
    {
        private readonly GeoContext _context;
        public TruckGeoPositionDao(GeoContext context)
        {
            _context = context;
        }
        public List<TruckGeoPosition> Get()
        {
            return _context.TruckGeoPositions.ToList();
        }
        public List<TruckInformationResponse> GetTravels() 
        {
            List<TruckInformationResponse> _result = (from travel in _context.TruckTravels
                         from or in _context.GeoPositions
                         from des in _context.GeoPositions
                         from truck in _context.TruckInfos
                         where travel.Status != "FINALIZADA" &&
                         travel.Status != "CANCELADA" &&
                         travel.IdTruck == truck.IdTruck &&
                         travel.IdOrigin == or.IdPosition &&
                         travel.IdOrigin == des.IdPosition 
                         select new TruckInformationResponse
                         {
                             IdTravel = travel.IdTravel,
                             IdOrigin = travel.IdOrigin,
                             IdDestination = travel.IdDestination,
                             IdTruck = travel.IdTruck,
                             Status = travel.Status,
                             Cargo = travel.Cargo,
                             LogDate = travel.LogDate,
                             Origin = or,
                             Destination = des,
                             Truck = truck,
                             
                         }).ToList();

            for (int i = 0; i < _result.Count; i++)
            {
                _result[i].Positions = new List<TruckGeoPosition>();
                List<TruckGeoPosition> _positions = _context.TruckGeoPositions
                    .Where(t => t.IdTruck == _result[i].IdTruck
                    && t.LogDate >= _result[i].LogDate)
                    .OrderByDescending(p => p.LogDate).ToList();                
                _result[i].Positions.AddRange(_positions);
            }
            return _result;
        }
        public TruckGeoPosition GetById(int id)
        {
            return _context.TruckGeoPositions
                .FirstOrDefault(g => g.IdPosition == id);
        }
        public bool Set(TruckGeoPosition _geo)
        {
            _context.TruckGeoPositions.Add(_geo);
            return (_context.SaveChanges() > 0);
        }
        public bool Update(int id, TruckGeoPosition _geo)
        {
            TruckGeoPosition geo = _context.TruckGeoPositions.Find(id);
            if (geo != null)
            {
                _geo.IdTruck = geo.IdTruck;
                _geo.Longitude = geo.Longitude;
                _geo.Latitude = geo.Latitude;
                _geo.Longitude = geo.Longitude;
                _geo.Speed = geo.Speed;
                _geo.SignalQuality = geo.SignalQuality;
                _geo.Satellites = geo.Satellites;
                _geo.Altitude = geo.Altitude;
                _geo.AltitudeUnits = geo.AltitudeUnits;
                _geo.GeoSep = geo.GeoSep;
                _geo.GeoSepUnits = geo.GeoSepUnits;
                _geo.AgeGpsData = geo.AgeGpsData;
                _geo.RefStationId = geo.RefStationId;
                _geo.LogDate = DateTime.Now;                
            }
            return (_context.SaveChanges() > 0);
        }
        public bool Delete(int id)
        {
            _context.TruckGeoPositions.Remove(_context.TruckGeoPositions.Find(id));
            return (_context.SaveChanges() > 0);
        }
    }
}
