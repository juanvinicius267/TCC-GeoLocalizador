using GeoLocalizador.BE.Infra;
using GeoLocalizador.BE.Models;
using System.Collections.Generic;
using System.Linq;

namespace GeoLocalizador.BE.Dao
{
    public class HarborDao
    {
        private readonly GeoContext _context;
        public HarborDao(GeoContext context)
        {
            _context = context;
        }
        public List<Harbor> Get()
        {
           return _context.Harbors
                .ToList();
        }
        public Harbor GetById(int id)
        {
            return _context.Harbors
                .FirstOrDefault(h => h.IdHarbor == id);
        }
        public bool Set(Harbor harbor)
        {
            _context.Harbors.Add(harbor);
            return _context.SaveChanges() > 0;
        }
        public bool Update(int id, Harbor harbor)
        {
            Harbor _harbor = _context.Harbors
                .FirstOrDefault(h => h.IdHarbor == id);
            if(harbor != null)
            {
                _harbor.IdMarineTraffic = harbor.IdMarineTraffic;
                _harbor.Name = harbor.Name;
                _harbor.Latitude = harbor.Latitude;
                _harbor.Longitude = harbor.Longitude;
                _harbor.Country = harbor.Country;
                _harbor.UrlPhoto = _harbor.UrlPhoto;
                _harbor.LastChange = _harbor.LastChange;
                return _context.SaveChanges() > 0;
            }
            else
            {
                return false;
            }
            
        }
        public bool Delete(int id)
        {
            Harbor harbor = _context.Harbors
                .FirstOrDefault(h => h.IdHarbor == id);
            _context.Harbors.Remove(harbor);
            return _context.SaveChanges() > 0;
        }
    }
}
