using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoLocalizador.BE.Models;
using GeoLocalizador.BE.Infra;

namespace GeoLocalizador.BE.Dao
{
    public class TruckInfoDao
    {
        private readonly GeoContext _context;
        public TruckInfoDao(GeoContext context)
        {
            _context = context;
        }
        public List<TruckInfo> Get()
        {
            return _context.TruckInfos.ToList();
        }
        public TruckInfo GetById(int id)
        {
            return _context.TruckInfos
                .FirstOrDefault(g => g.IdTruck == id);
        }

        public bool Set(TruckInfo _truck)
        {
            _context.TruckInfos.Add(_truck);
            return (_context.SaveChanges() > 0);
        }
        public bool Update(int id, TruckInfo _truck)
        {
            TruckInfo truck = _context.TruckInfos.Find(id);
            if (truck != null)
            {
                _truck.LicensePlate = truck.LicensePlate;
                _truck.Carrier = truck.Carrier;
                _truck.VolumeCapacity = truck.VolumeCapacity;
                _truck.WeightCapacity = truck.WeightCapacity;
                _truck.Model = truck.Model;
                _truck.LastUpdateDate = DateTime.Now;
            }
            return (_context.SaveChanges() > 0);
        }
        public bool Delete(int id)
        {
            _context.TruckInfos.Remove(_context.TruckInfos.Find(id));
            return (_context.SaveChanges() > 0);
        }
    }
}
