using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocalizador.BE.Dao
{
    public class VesselTravelDao
    {
        private readonly GeoContext _context;
        public VesselTravelDao(GeoContext context)
        {
            _context = context;
        }
        public List<VesselTravel> Get()
        {
            return _context.VesselTravels.ToList();
        }
        public VesselTravel GetById(int id)
        {
            return _context.VesselTravels
                .FirstOrDefault(g => g.IdTravel == id);
        }

        public bool Set(VesselTravel _vessel)
        {
            _context.VesselTravels.Add(_vessel);
            return (_context.SaveChanges() > 0);
        }
        public bool Update(int id, VesselTravel _vessel)
        {
            VesselTravel vessel = _context.VesselTravels.Find(id);
            if (vessel != null)
            {
                _vessel.IdOrigin = vessel.IdOrigin;
                _vessel.IdDestination = vessel.IdDestination;
                _vessel.IdVessel = vessel.IdVessel;
                _vessel.Cargo = vessel.Cargo;
                _vessel.Status = vessel.Status;
            }
            return (_context.SaveChanges() > 0);
        }
        public bool Delete(int id)
        {
            _context.VesselTravels.Remove(_context.VesselTravels.Find(id));
            return (_context.SaveChanges() > 0);
        }
    }
}
