using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Dao
{
    public class TruckTravelDao
    {
        private readonly GeoContext _context;
        public TruckTravelDao(GeoContext context)
        {
            _context = context;
        }
        public List<TruckTravel> Get()
        {
            return _context.TruckTravels.ToList();
        }
        public TruckTravel GetById(int id)
        {
            return _context.TruckTravels
                .FirstOrDefault(g => g.IdTravel == id);
        }

        public bool Set(TruckTravel _truck)
        {
            _context.TruckTravels.Add(_truck);
            return (_context.SaveChanges() > 0);
        }
        public bool Update(int id, TruckTravel _truck)
        {
            TruckTravel truck = _context.TruckTravels.Find(id);
            if (truck != null)
            {
                _truck.IdOrigin = truck.IdOrigin;
                _truck.IdDestination = truck.IdDestination;
                _truck.IdTruck = truck.IdTruck;
                _truck.Cargo = truck.Cargo;
                _truck.Status = truck.Status;
            }
            return (_context.SaveChanges() > 0);
        }
        public bool Delete(int id)
        {
            _context.TruckTravels.Remove(_context.TruckTravels.Find(id));
            return (_context.SaveChanges() > 0);
        }
    }
}
