using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Dao
{
    public class VesselGeoPositionDao
    {
        private readonly GeoContext _context;
        public VesselGeoPositionDao(GeoContext context)
        {
            _context = context;
        }
        public List<VesselGeoPosition> Get()
        {
            return _context.VesselGeoPositions
                 .ToList();
        }
        public VesselGeoPosition GetById(int id)
        {
            return _context.VesselGeoPositions
                .FirstOrDefault(h => h.IdPosition == id);
        }
        public bool Set(VesselGeoPosition position)
        {
            _context.VesselGeoPositions.Add(position);
            return _context.SaveChanges() > 0;
        }
        public bool Update(int id, VesselGeoPosition position)
        {
            VesselGeoPosition _position = _context.VesselGeoPositions
                .FirstOrDefault(h => h.IdPosition == id);
            if (position != null)
            {
                _position.IdVesselInfo = position.IdVesselInfo;
                _position.LastPositionReceived = position.LastPositionReceived;
                _position.Latitude = position.Latitude;
                _position.Longitude = position.Longitude;
                _position.LocationArea = position.LocationArea;
                _position.Current_Port = _position.Current_Port;
                _position.Status = _position.Status;
                _position.SpeedCourse = _position.SpeedCourse;
                _position.AISSource = _position.AISSource;
                _position.LogDate = DateTime.Now;
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            VesselGeoPosition position = _context.VesselGeoPositions
                .FirstOrDefault(h => h.IdPosition == id);
            _context.VesselGeoPositions.Remove(position);
            return _context.SaveChanges() > 0;
        }
    }
}
