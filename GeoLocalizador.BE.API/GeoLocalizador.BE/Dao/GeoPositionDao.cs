using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Dao
{
    public class GeoPositionDao
    {
        private readonly GeoContext _context;
        public GeoPositionDao(GeoContext context)
        {
            _context = context;
        }
        public List<GeoPosition> Get()
        {
            return _context.GeoPositions.ToList();
        }
        public GeoPosition GetById(int id)
        {
            return _context.GeoPositions
                .FirstOrDefault(g => g.IdPosition == id);
        }
        public bool Set(GeoPosition _geo)
        {
            _context.GeoPositions.Add(_geo);
            return (_context.SaveChanges() > 0);
        }
        public bool Update(int id, GeoPosition _geo)
        {
            GeoPosition geo = _context.GeoPositions.Find(id);
            if(geo != null)
            {
                _geo.Latitude = geo.Latitude;
                _geo.Longitude = geo.Longitude;
                _geo.Name = geo.Name;
                _geo.Number = geo.Number;
                _geo.State = geo.State;
                _geo.Street = geo.Street;
                _geo.ZipCode = geo.ZipCode;
                _geo.City = geo.City;
                _geo.Country = geo.Country;
            }
            return (_context.SaveChanges() > 0);
        }
        public bool Delete(int id)
        {
            _context.GeoPositions.Remove(_context.GeoPositions.Find(id));
            return (_context.SaveChanges() > 0);
        }
    }
}
